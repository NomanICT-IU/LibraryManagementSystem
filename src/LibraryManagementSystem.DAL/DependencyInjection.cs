namespace LibraryManagementSystem.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDallServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(sp =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddScoped<IBookRepositroy, BookRepositroy>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IBookCopyRepository, BookCopyRepository>();
            services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
            services.AddScoped<IMemberSearchRepository, MemberSearchRepository>();


            return services;

        }
    }
}
