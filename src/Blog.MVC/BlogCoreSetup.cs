using Blog.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.MVC.Setup
{
    internal static class BlogCoreSetup
    {
        public static void AddBlogCoreSingletons(IServiceCollection services)
        {
            AddSingleton_Builders(services);
            AddSingleton_FileDataAccess(services);
            AddSingleton_FileDataAccessAdapters(services);
            AddSingleton_Repositories(services);
            AddSingleton_Validators(services);
            AddSingleton_UseCaseInteractors(services);
        }

        private static void AddSingleton_Builders(IServiceCollection services)
        {
            services.AddSingleton<ISqlParameterBuilder, SqlParameterBuilder>();
        }

        private static void AddSingleton_FileDataAccess(IServiceCollection services)
        {
            services.AddSingleton<IFileReader, FileReader>();
            services.AddSingleton<IFileWriter, FileWriter>();
            services.AddSingleton(typeof(IFileDataAccess<>), typeof(FileDataAccess<>));
        }

        private static void AddSingleton_FileDataAccessAdapters(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostDataAccessAdapter, BlogPostFileAdapter>();
            services.AddSingleton<IBlogUserDataAccessAdapter, BlogUserFileAdapter>();
        }

        private static void AddSingleton_Repositories(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostRepository, BlogPostRepository>();
            services.AddSingleton<IBlogUserRepository, BlogUserRepository>();
        }

        private static void AddSingleton_SqlServerDataAccess(IServiceCollection services)
        {
            services.AddSingleton<ISqlServerDataAccess, SqlServerDataAccess>();
        }

        private static void AddSingleton_SqlServerDataAccessAdapters(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostDataAccessAdapter, BlogPostSqlServerAdapter>();
            services.AddSingleton<IBlogUserDataAccessAdapter, BlogUserSqlServerAdapter>();
        }

        private static void AddSingleton_UseCaseInteractors(IServiceCollection services)
        {
            services.AddSingleton<IAddBlogPostInteractor, AddBlogPostInteractor>();
            services.AddSingleton<IDeleteBlogPostInteractor, DeleteBlogPostInteractor>();
            services.AddSingleton<IEditBlogPostInteractor, EditBlogPostInteractor>();
            services.AddSingleton<IGetBlogPostInteractor, GetBlogPostInteractor>();
            services.AddSingleton<IListBlogPostsInteractor, ListBlogPostsInteractor>();
            services.AddSingleton<IListBlogUsersInteractor, ListBlogUsersInteractor>();
            services.AddSingleton<IListRecentBlogPostsInteractor, ListRecentBlogPostsInteractor>();
            services.AddSingleton<ILoginUserInteractor, LoginUserInteractor>();
            services.AddSingleton<IRegisterUserInteractor, RegisterUserInteractor>();
        }

        private static void AddSingleton_Validators(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostValidator, BlogPostValidator>();
            services.AddSingleton<IBlogUserValidator, BlogUserValidator>();
        }

        private static void AddSingleton_WebApiDataAccess(IServiceCollection services)
        {
            services.AddSingleton<IWebApiDataAccess, WebApiDataAccess>();
        }

        private static void AddSingleton_WebApiDataAccessAdapters(IServiceCollection services)
        {
            services.AddSingleton<IBlogPostDataAccessAdapter, BlogPostWebApiAdapter>();
            services.AddSingleton<IBlogUserDataAccessAdapter, BlogUserWebApiAdapter>();
        }
    }
}
