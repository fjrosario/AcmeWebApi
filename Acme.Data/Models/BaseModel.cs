using Microsoft.OpenApi.Any;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data.Models
{
    public abstract class BaseModel
    {
        ///<example>0</example>
        ///<default>0</default>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue(0)]
        [SwaggerSchema("Identifier", Nullable=true)]
        public int Id { get; set; }

    }
}
