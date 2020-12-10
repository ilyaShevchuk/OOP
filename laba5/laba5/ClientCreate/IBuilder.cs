namespace laba5.ClientCreate
{
    public interface IBuilder
    {
        IBuilder SetName(string name);
        IBuilder SetSurname(string surname);
        IBuilder SetAdress(string adress);
        IBuilder SetPassport(string passport);
        ClientCreate.Client Build();
    }
}