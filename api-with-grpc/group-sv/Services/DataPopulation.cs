using group_sv.Models;
using System.Text.Json;

namespace group_sv.Services
{
    public static class DataPopulation
    {
        public static void PopulateGroup(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                GroupContext context = scope.ServiceProvider.GetRequiredService<GroupContext>();

                if(!context.Groups.Any())
                {
                    Console.WriteLine("Seeding new Groups...");
                    int[] nums = {1, 2};
                    IList<Group> groups = new List<Group>();
                    foreach(int num in nums)
                    {
                        Group Group = new Group{GroupId=num, GroupName=$"Group {num}"};
                        groups.Add(Group);
                    }
                    context.Groups.AddRange(groups);
                    int result = context.SaveChanges();
                    if(result > 0)
                    {
                        Console.WriteLine($"Finish seeding Groups!");
                        Console.WriteLine(JsonSerializer.Serialize<IEnumerable<Group>>(context.Groups));
                    }else{
                        Console.WriteLine($"Error seeding Groups!");
                    }

                }
            }
        }
    }
}