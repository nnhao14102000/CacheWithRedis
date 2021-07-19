using System.Linq;

namespace CacheWithRedis.Models
{
    public static class DbInitializer
    {
        public static void Initializer(TodoContext context)
        {
            context.Database.EnsureCreated();

            if (!context.TodoItems.Any())
            {
                var items = new TodoItem[]
                {
                    new TodoItem{Name = "Run this project...", IsComplete=true},
                    new TodoItem{Name = "Thanks you so much!", IsComplete=true}
                };
                context.AddRange(items);
                context.SaveChanges();
            }
        }
    }
}
