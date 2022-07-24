namespace member_sv_setting.Models
{
    public static class SeedDb
    {
        public static void Populate(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                Seed(scope.ServiceProvider.GetService<MemberSettingContext>());
            }
        }

        public static void Seed(MemberSettingContext? context)
        {
            if(!context!.MemberSettings.Any())
            {
                Console.WriteLine("<--- Success Seeding data --->");
                IList<MemberSvSetting> settings = new List<MemberSvSetting>{
                    new MemberSvSetting{Id=1,Name="Name"},
                    new MemberSvSetting{Id=2,Name="Password"},
                    new MemberSvSetting{Id=3,Name="Profile"},
                };

                context.MemberSettings.AddRange(settings);
                context.SaveChanges();
            }else{
                Console.WriteLine("<--- Failed Seeding data --->");
            }
        }
    }
}