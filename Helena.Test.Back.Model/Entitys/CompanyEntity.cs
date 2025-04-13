namespace Helena.Test.Back.Model.Entitys
{
    public class CompanyEntity
    {
        public long Id { get; set; }
        public string AvatarUrl { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public long QtdeFuncionarios { get; set; }
        public bool Active { get; set; }
    }

}
