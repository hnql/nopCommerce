using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Database.UserRelated.Domains;
using Nop.Data.Extensions;

namespace Nop.Plugin.Database.UserRelated.Mapping.Builders
{
    class UserBuilder : NopEntityBuilder<User>
    {
        #region Methods
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //table.WithColumn(nameof(User.Id)).AsInt32().PrimaryKey().Identity()
            //table.WithColumn(nameof(User.Id)).AsInt32().PrimaryKey().ForeignKey<Customer>(onDelete: Rule.Cascade)
            table.WithColumn(nameof(User.Id)).AsInt32().PrimaryKey().ForeignKey<Customer>(onDelete: Rule.Cascade)
            .WithColumn(nameof(User.UserName)).AsString(1000)
            .WithColumn(nameof(User.Password)).AsString(int.MaxValue)
            .WithColumn(nameof(User.FirstName)).AsString(int.MaxValue)
            .WithColumn(nameof(User.LastName)).AsString(int.MaxValue)
            .WithColumn(nameof(User.Email)).AsString(int.MaxValue)
            .WithColumn(nameof(User.Address)).AsString(int.MaxValue)
            .WithColumn(nameof(User.PhoneNumber)).AsString(int.MaxValue)
            .WithColumn(nameof(User.Details)).AsString(int.MaxValue)
            .WithColumn(nameof(User.IsActive)).AsBoolean();
        }

        #endregion
    }
}
