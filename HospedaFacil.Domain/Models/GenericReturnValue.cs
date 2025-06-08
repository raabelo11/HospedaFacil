namespace HospedaFacil.Domain.Models
{
    public class GenericReturnValue
    {
        public bool sucess { get; set; } = true;
        public object? data { get; set; }
        public string? error { get; set; }

        public GenericReturnValue(string? erros = null)
        {
            if (erros is not null)
                this.sucess = false;
        }
    }
}
