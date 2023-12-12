using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ApplicationServiceRegistration  //  applicationla ilgili bütün registrationlaru burada yapacagız program.cs i bunlarla kirletmeyeceğiz. sadece ApplicationServiceRegistration'ı program cs e dahil edicez
{
    // extension yazacağız, extension yazabilmek icin methodun static olması gerekiyor
    // biz neyi extend edeceksek onu this keyword ü ile veriyoruz.
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            // burada mediatr a diyoruz ki, git bütün assembly yi tara orada commandleri queryleri bul onların handlerlerini bul birbiriyle eşleştir listene koy ben yarın bir command send yaparsam git handler ını bul calıstır.
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); //mevcut Assembly de ara demiş oluyoruz.
        });

        return services;
    }
}
