using Acme.Data;
using Acme.Data.Models;
using Acme.Data.Repositories;
using Acme.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Builder;
using Swashbuckle;
using System;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using System.ComponentModel;
using System.Reflection;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;

/*
public class DefaultValuesSwaggerExtensions : Swashbuckle.AspNetCore.SwaggerGen.ISchemaFilter
{
public void Apply(OpenApiSchema schema, SchemaFilterContext context)
{
    var attributes = context?.MemberInfo?.GetCustomAttributes().OfType<Acme.Data.DefaultValueAttribute>();

    if (attributes?.Any() == true)
    {
        var val = attributes.First().Value;
        schema.Default = val;
        schema.Example = val;
    }
}
}*/
internal class Program
{
    [UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "<Pending>")]
    [UnconditionalSuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "<Pending>")]
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.WriteIndented = true;
        });




        builder.Services.AddDbContextFactory<AcmeDataContext>(optionsBuilder =>
        {
            var options = optionsBuilder.UseInMemoryDatabase(databaseName: "Acme");
        }
        );

        builder.Services.AddScoped<IAcmeDataContext, AcmeDataContext>();
        builder.Services.AddTransient<IContactRepository, ContactRepository<AcmeDataContext>>();
        builder.Services.AddTransient<IAddressRepository, AddressRepository<AcmeDataContext>>();
        builder.Services.AddTransient<IOrderRepository, OrderRepository<AcmeDataContext>>();
        builder.Services.AddTransient<IContactService, ContactService>();
        builder.Services.AddTransient<IAddressService, AddressService>();
        builder.Services.AddTransient<IOrderService, OrderService>();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
        });

        builder.Services.AddHealthChecks();


        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "v1",
                Title = " API",
                Description = "API for the  Server",

            });
            c.UseAllOfToExtendReferenceSchemas();
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapHealthChecks("/health");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        IContactService contactService = null;
        IAddressService addressService = null;
        IOrderService orderService = null;

        contactService = app.Services.GetRequiredService<IContactService>();
        addressService = app.Services.GetRequiredService<IAddressService>();
        orderService = app.Services.GetRequiredService<IOrderService>();

        var contactsApi = app.MapGroup("/contacts");
        contactsApi.MapPost("/", (Acme.Data.Models.Contact contact) =>
        {
            contactService.AddContact(contact);
            return TypedResults.Created($"/contacts/{contact.Id}", contact);
        });

        contactsApi.MapGet("/", () =>
        {
            var contacts = contactService.GetContacts();
            return TypedResults.Ok(contacts);
        });

        contactsApi.MapGet("/{id}", (int id) =>
        {
            var contact = contactService.GetContact(id);
            if (contact is null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(contact);
        });

        contactsApi.MapPut("/{id}", (int id, Acme.Data.Models.Contact contact) =>
        {
            if (contact.Id != id)
            {
                return Results.BadRequest();
            }
            contactService.UpdateContact(contact);
            return TypedResults.Ok(contact);
        });

        contactsApi.MapDelete("/{id}", (int id) =>
        {
            var contact = contactService.GetContact(id);
            if (contact is null)
            {
                return TypedResults.NotFound();
            }
            contactService.DeleteContact(contact);
            return Results.NoContent();
        });

        var addressesApi = app.MapGroup("/addresses");

        addressesApi.MapPost("/", (Address address) =>
        {
            addressService.AddAddress(address);
            return TypedResults.Created($"/addresses/{address.Id}", address);
        });

        addressesApi.MapGet("/", () =>
        {
            var addresses = addressService.GetAddresses();
            return TypedResults.Ok(addresses);
        });

            addressesApi.MapGet("/{id}", (int id) =>
            {
            var address = addressService.GetAddress(id);
            if (address is null)
                {
                return Results.NotFound();
            }
            return TypedResults.Ok(address);
        });

        addressesApi.MapPut("/{id}", (int id, Address address) =>
        {
            if (address.Id != id)
            {
                return Results.BadRequest();
            }
            addressService.UpdateAddress(address);
            return TypedResults.Ok(address);
        });

        addressesApi.MapDelete("/{id}", (int id) =>
        {
            var address = addressService.GetAddress(id);
            if (address is null)
            {
                return Results.NotFound();
            }
            addressService.DeleteAddress(address);
            return Results.NoContent();
        });

        var ordersApi = app.MapGroup("/orders");

        ordersApi.MapPost("/", (Order order) =>
        {
            orderService.AddOrder(order);
            return TypedResults.Created($"/orders/{order.Id}", order);
        });

        ordersApi.MapGet("/", () =>
        {
            var orders = orderService.GetOrders();
            return TypedResults.Ok(orders);
        });

        ordersApi.MapGet("/{id}", (int id) =>
        {
            var order = orderService.GetOrder(id);
            if (order is null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(order);
        });

        ordersApi.MapPut("/{id}", (int id, Order order) =>
        {
            if (order.Id != id)
            {
                return Results.BadRequest();
            }
            orderService.UpdateOrder(order);
            return TypedResults.Ok(order);
        });

        ordersApi.MapDelete("/{id}", (int id) =>
        {
            var order = orderService.GetOrder(id);
            if (order is null)
            {
                return Results.NotFound();
            }
            orderService.DeleteOrder(order);
            return Results.NoContent();
        });

        app.Run();
    }

}

