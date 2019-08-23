# Build Status

[![Build status](https://ci.appveyor.com/api/projects/status/688fr0frotwxft7g/branch/master?svg=true)](https://ci.appveyor.com/project/mateusggeracino/swaggerlib/branch/master)


## Como utilizar (Padrão)

Execute o comando abaixo no Package Manager Console
```bash
Install-Package SwaggerLib.MGG
```

Após é necessário adicionar a referência da lib na classe Startup

```csharp
        using SwaggerLib.Services;
```

Assim, basta chamar o método de configuração no método: ConfigureServices

O valor booleano passado por parâmetro é responsável por implementar o método de Token no swagger.
True = Usar método de Token
False = Não usar método de Token

Como abaixo:
 ```csharp
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Here
            services.ConfigureServicesSwagger(true);
        }
```

Também devemos chamar o método de extensão no método: Configure

Como abaixo:
 ```csharp
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Here
            app.ConfigureAppSwagger();

            app.UseMvc();
        }
```

Veja a imagen no sistema implementado:

![alt text](https://i.ibb.co/9V12TQS/sistema-implementado-sem-token-padrao.png)



## Como utilizar (Mensagens Personalizadas)
É necessário criar uma classe com métodos de extensão para as interfaces: IServiceCollection e IApplicationBuilder

Imagem da estrutura e código da classe abaixo:

![alt text](https://i.ibb.co/jLydCCW/estrutura.png)

Código classe de extensão:

 ```csharp
    public static class SwaggerConfig
    {
        /// <summary>
        /// Método de extensão da interface: IServiceCollection
        /// Propriedades personalizadas 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigSwaggerServices(this IServiceCollection services)
        {
            SwaggerContact.Config("Joseé", "link do repositório");
            SwaggerInfo.Config("v1", "Josézinho", "Test");

            services.ConfigureServicesSwagger(true);
        }

        /// <summary>
        /// Método de extensão da interface: IApplicationBuilder
        /// Propriedades de EndPoint personalizadas
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigSwaggerApp(this IApplicationBuilder app)
        {
            SwaggerEndPoint.Config("/swagger/v1/swagger.json", "Josezinho");

            app.ConfigureAppSwagger();
        }
    }
   
```

Após, basta chamar o método na classe Startup:
Método: ConfigureServices
```csharp
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Here
            services.ConfigSwaggerServices();
        }
```  
      
Método: Configure

```csharp
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            //Here
            app.ConfigSwaggerApp();
            app.UseMvc();
        }
```
    
Imagems do sistema implementado:

Sistema sem Token
![alt text](https://i.ibb.co/8KL7h8F/sistema-implementado-sem-token.png)

Sistema com Token
![alt text](https://i.ibb.co/f1wZSss/sistema-implementado.png)

Utilizando o Token
![alt text](https://i.ibb.co/SmnyYXp/sistema-implementado-token.png)
