namespace LibraryManagementSystem.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IBookCopyService, BookCopyService>();

            return services;

        }
    }
}
