using Lms.Api.DTO;

namespace Lms.Api.Schema.Mutation
{
   
    public class ResetPasswordInputType : InputObjectType<ResetPasswordDTO>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ResetPasswordDTO> descriptor)
        {
            descriptor.Field(t => t.ResetToken).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.NewPassword).Type<NonNullType<StringType>>();
        }
    }

}
