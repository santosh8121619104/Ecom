using Lms.Api.Models;

public class EnrollmentInputType : InputObjectType<Enrollment>
{
    protected override void Configure(IInputObjectTypeDescriptor<Enrollment> descriptor)
    {
        descriptor.Description("Input type for creating or updating an enrollment.");

        descriptor.Field(e => e.UserId)
            .Type<IntType>();

        descriptor.Field(e => e.CourseId)
            .Type<IntType>();

        descriptor.Field(e => e.EnrollmentDate)
            .Type<DateTimeType>();

        descriptor.Field(e => e.UserName)
            .Type<StringType>();

        descriptor.Field(e => e.CreatedBy)
            .Type<StringType>();

        descriptor.Field(e => e.CreateDate)
            .Type<DateTimeType>();

        descriptor.Field(e => e.ModifiedBy)
            .Type<StringType>();

        descriptor.Field(e => e.ModifiedDate)
            .Type<DateTimeType>();

        // Ensure all fields are properly mapped to the GraphQL schema
    }
}