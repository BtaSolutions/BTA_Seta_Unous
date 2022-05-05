using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Supplier
    {
        //SupplierCode          [nvarchar] (8)	NOT NULL    Código do Fornecedor
        public string SupplierCode { get; set; }
        //SupplierName          [nvarchar](100)	NOT NULL    Nome do Fornecedor
        public string SupplierName { get; set; }
        //SocialName            [nvarchar]  NULL Razão Social
        public string SocialName { get; set; }
        //IsActive              [bit]   NOT NULL    Ativo/Inativo	1 – Ativo/ 0 – Inativo
        public bool IsActive { get; set; }
        //CNPJ                  [nvarchar](15)	NOT NULL    Número do CNPJ
        public string CNPJ { get; set; }
        //StateRegistration     [nvarchar](12)	NULL Número da Inscrição Estadual
        public string StateRegistration { get; set; }
        //MunicipalRegistration [nvarchar](10)	NULL Número da Inscrição Municipal
        public string MunicipalRegistration { get; set; }
        //Address               [nvarchar](250)	NULL Endereço(Rua, Avenida, ect)
        public string Address { get; set; }
        //Number                [nvarchar] (10)	NULL Número do Endereço
        public string Number { get; set; }
        //District              [nvarchar](100)	NULL Bairro
        public string District { get; set; }
        //State                 [nvarchar] (2)	NULL Estado
        public string State { get; set; }
        //City                  [nvarchar] (200)	NULL Cidade
        public string City { get; set; }
        //Country               [nvarchar] (120)	NULL País
        public string Country { get; set; }
        //Complement            [nvarchar] (120)	NULL Complemento do Endereço
        public string Complement { get; set; }
        //ZipCode               [nvarchar](8)	NULL CEP
        public string ZipCode { get; set; }
        //Contact               [nvarchar] (100)	NULL Nome de Contato Opcional
        public string Contact { get; set; }
        //PaymentTerm           [int]   NULL Dia de Pagamento    Opcional
        public string PaymentTerm { get; set; }
        //Phone                 [nvarchar](11)	NULL Telefone de Contato Opcional
        public string Phone { get; set; }
        //EMAIL                 [nvarchar](150)	NULL E-mail de contato Opcional
        public string EMAIL { get; set; }

    }
}
