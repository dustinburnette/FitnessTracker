namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseTypes",
                c => new
                    {
                        ExerciseTypeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExerciseTypes");
        }
    }
}
