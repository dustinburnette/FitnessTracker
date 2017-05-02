namespace FitnessTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseSessions",
                c => new
                    {
                        ExerciseSessionID = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ExerciseTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseSessionID)
                .ForeignKey("dbo.ExerciseTypes", t => t.ExerciseTypeID, cascadeDelete: true)
                .Index(t => t.ExerciseTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExerciseSessions", "ExerciseTypeID", "dbo.ExerciseTypes");
            DropIndex("dbo.ExerciseSessions", new[] { "ExerciseTypeID" });
            DropTable("dbo.ExerciseSessions");
        }
    }
}
