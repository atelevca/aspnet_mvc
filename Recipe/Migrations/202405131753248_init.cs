namespace Recipe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Ingredients = c.String(),
                        Instructions = c.String(),
                        Cuisine = c.String(),
                        Servings = c.Int(nullable: false),
                        PreparationTime = c.Int(nullable: false),
                        CookingTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recipes");
        }
    }
}
