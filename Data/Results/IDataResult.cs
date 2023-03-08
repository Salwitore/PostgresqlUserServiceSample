using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Results
{
    public interface IDataResult<out T> : IResult
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        T Data { get; }
    }

}
