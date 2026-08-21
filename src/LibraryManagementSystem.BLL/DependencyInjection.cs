using FluentValidation;
using LibraryManagementSystem.BLL.Validators;

namespace LibraryManagementSystem.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IBookCopyService, BookCopyService>();
            services.AddScoped<IBorrowRecordService, BorrowRecordService>();

            services.AddValidatorsFromAssemblyContaining<BookDtoValidator>();
            return services;

        }
    }
}
