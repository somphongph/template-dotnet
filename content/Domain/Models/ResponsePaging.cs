using System.Text.Json.Serialization;
using Domain.Enumerables;
using Domain.Extensions;

namespace Domain.Models;

public class ResponsePaging<T> : BaseResponse
{
    public ResponsePaging() { }
    public ResponsePaging(ResponseStatus status)
    {
        Code = status.Code();
        Message = status.NameString();
    }

    [JsonPropertyOrder(4)]
    public bool IsCached { get; set; }

    [JsonPropertyOrder(5)]
    public int Page { get; set; }

    [JsonPropertyOrder(6)]
    public int Limit { get; set; }

    [JsonPropertyOrder(7)]
    public long Total { get; set; }

    [JsonPropertyOrder(8)]
    public IEnumerable<T>? Data { get; set; }
}
