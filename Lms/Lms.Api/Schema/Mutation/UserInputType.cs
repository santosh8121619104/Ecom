using Lms.Api.DTO;
using Lms.Api.Models;

namespace Lms.Api.Schema.Mutation
{
    public class UserInputType : InputObjectType<UserDTO>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UserDTO> descriptor)
        {
            descriptor.Description("Input type for creating or updating a user.");

            descriptor.Field(u => u.FirstName)
                .Type<StringType>();

            descriptor.Field(u => u.LastName)
                .Type<StringType>();

            descriptor.Field(u => u.Email)
                .Type<StringType>();

            descriptor.Field(u => u.Password)
                .Type<StringType>();

            descriptor.Field(u => u.UserType)
                .Type<StringType>();

            descriptor.Field(u => u.CreatedBy)
                .Type<StringType>();

            descriptor.Field(u => u.CreateDate)
                .Type<DateTimeType>();

            descriptor.Field(u => u.ModifiedBy)
                .Type<StringType>();

            descriptor.Field(u => u.ModifiedDate)
                .Type<DateTimeType>();
        }
    }
}
