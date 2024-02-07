using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration  //  applicationla ilgili bütün registrationlaru burada yapacagız program.cs i bunlarla kirletmeyeceğiz. sadece ApplicationServiceRegistration'ı program cs e dahil edicez
{
    // extension yazacağız, extension yazabilmek icin methodun static olması gerekiyor
    // biz neyi extend edeceksek onu this keyword ü ile veriyoruz.
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            // burada mediatr a diyoruz ki, git bütün assembly yi tara orada commandleri queryleri bul onların handlerlerini bul birbiriyle eşleştir listene koy ben yarın bir command send yaparsam git handler ını bul calıstır.
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); //mevcut Assembly de ara demiş oluyoruz.

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));

        });

        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {//bu bir extension method.
        //git assembly icinde benim subclass olarak verdigim (BaseBusinessRules) olanları bul onları lifecyle ına yani ioc ye ekle.
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var t in types)
        {
            if (addWithLifeCycle == null)
                services.AddScoped(t);
            else
                addWithLifeCycle(services, type);
        }

        return services;
    }

}
