using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helena.Test.Back.Repository.Querys
{
    public static class CompanyQuerys
    {
        public static string CreateQuery => @"
            INSERT INTO Company (
                AvatarUrl, 
                NomeFantasia, 
                RazaoSocial, 
                QtdeFuncionarios, 
                Active
            ) 
            VALUES (
                @AvatarUrl, 
                @NomeFantasia, 
                @RazaoSocial, 
                @QtdeFuncionarios, 
                @Active
            );
            SELECT LAST_INSERT_ID();";

        public static string DeleteQuery => "DELETE FROM Company WHERE Id = @Id";

        public static string GetAllQuery => @"
            SELECT 
                *
            FROM Company";

        public static string GetByIdQuery => @"
            SELECT 
                *
            FROM Company 
            WHERE Id = @Id";

        public static string GetByRazaoSocialQuery => @"
            SELECT 
                Id, 
                AvatarUrl, 
                NomeFantasia, 
                RazaoSocial, 
                QtdeFuncionarios, 
                Active 
            FROM Company 
            WHERE RazaoSocial = @RazaoSocial";

        public static string UpdateQuery => @"
            UPDATE Company 
            SET 
                AvatarUrl = @AvatarUrl,
                NomeFantasia = @NomeFantasia,
                RazaoSocial = @RazaoSocial,
                QtdeFuncionarios = @QtdeFuncionarios,
                Active = @Active
            WHERE Id = @Id";
    }
}
