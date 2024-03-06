using HotChocolate.Types;
using Lms.Api.Models;

public class CourseType : ObjectType<Course>
{
    protected override void Configure(IObjectTypeDescriptor<Course> descriptor)
    {
        descriptor.Description("Represents a course.");

        descriptor.Field(c => c.CourseId)
            .Description("The unique identifier of the course.")
            .Type<NonNullType<IdType>>();

        descriptor.Field(c => c.CourseName)
            .Description("The name of the course.")
            .Type<StringType>();

        descriptor.Field(c => c.Description)
            .Description("The description of the course.")
            .Type<StringType>();

        descriptor.Field(c => c.InstructorId)
            .Description("The ID of the instructor for the course.")
            .Type<IntType>();

        descriptor.Field(c => c.InstructorName)
            .Description("The name of the instructor for the course.")
            .Type<StringType>();

        descriptor.Field(c => c.CreatedBy)
            .Description("The user who created the course.")
            .Type<StringType>();

        descriptor.Field(c => c.CreateDate)
            .Description("The date when the course was created.")
            .Type<DateTimeType>();

        descriptor.Field(c => c.ModifiedBy)
            .Description("The user who last modified the course.")
            .Type<StringType>();

        descriptor.Field(c => c.ModifiedDate)
            .Description("The date when the course was last modified.")
            .Type<DateTimeType>();

    
    }
}
