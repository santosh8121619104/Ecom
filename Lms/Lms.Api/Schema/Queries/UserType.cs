using HotChocolate.Types;
using Lms.Api.Models;


public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Description("Represents a user.");

        descriptor.Field(u => u.UserId)
            .Description("The unique identifier of the user.")
            .Type<IntType>();

        descriptor.Field(u => u.FirstName)
            .Description("The first name of the user.")
            .Type<StringType>();

        descriptor.Field(u => u.LastName)
            .Description("The last name of the user.")
            .Type<StringType>();

        descriptor.Field(u => u.Email)
            .Description("The email address of the user.")
            .Type<StringType>();

        descriptor.Field(u => u.Password)
            .Description("The password of the user.")
            .Type<StringType>();

        descriptor.Field(u => u.UserType)
            .Description("The type of the user.")
            .Type<StringType>();

        descriptor.Field(u => u.CreatedBy)
            .Description("The user who created the user record.")
            .Type<StringType>();

        descriptor.Field(u => u.CreateDate)
            .Description("The date when the user was created.")
            .Type<DateTimeType>();

        descriptor.Field(u => u.ModifiedBy)
            .Description("The user who last modified the user record.")
            .Type<StringType>();

        descriptor.Field(u => u.ModifiedDate)
            .Description("The date when the user record was last modified.")
            .Type<DateTimeType>();
    }
}


