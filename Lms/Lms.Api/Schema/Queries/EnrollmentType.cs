using Lms.Api.Models;

public class EnrollmentType : ObjectType<Enrollment>
{
    protected override void Configure(IObjectTypeDescriptor<Enrollment> descriptor)
    {
        descriptor.Description("Represents the type for an enrollment.");

        descriptor.Field(e => e.EnrollmentId)
            .Description("The unique identifier of the enrollment.")
            .Type<IdType>();

        descriptor.Field(e => e.UserId)
            .Description("The ID of the user enrolled.")
            .Type<IntType>();

        descriptor.Field(e => e.CourseId)
            .Description("The ID of the course enrolled.")
            .Type<IntType>();

        descriptor.Field(e => e.EnrollmentDate)
            .Description("The date when the enrollment was made.")
            .Type<DateTimeType>();

        descriptor.Field(e => e.UserName)
            .Description("The name of the user enrolled.")
            .Type<StringType>();

        descriptor.Field(e => e.CreatedBy)
            .Description("The user who created the enrollment.")
            .Type<StringType>();

        descriptor.Field(e => e.CreateDate)
            .Description("The date when the enrollment was created.")
            .Type<DateTimeType>();

        descriptor.Field(e => e.ModifiedBy)
            .Description("The user who last modified the enrollment.")
            .Type<StringType>();

        descriptor.Field(e => e.ModifiedDate)
            .Description("The date when the enrollment was last modified.")
            .Type<DateTimeType>();

        // Define fields for related entities if needed
        // For example:
        // descriptor.Field(e => e.User)
        //     .Type<UserType>();
        // descriptor.Field(e => e.Course)
        //     .Type<CourseType>();

        // Ensure all fields are properly mapped to the GraphQL schema
    }
}