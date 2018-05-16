using CartClient.Services;
using CartClient.Services.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using CartClient.Services.Internal;
using CartClient.Services.Internal.Imp;
using CartClient.Models;
using CartClient.Demo.Services;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CartClient.Demo
{
    /// <summary>
    /// Program
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //Setup of DI
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IConfigurationService, ConfigurationService>()
                .AddSingleton<ITokenService, TokenService>()
                .AddSingleton<ICartService, CartService>()
                .BuildServiceProvider();

            ICartService cartService = serviceProvider.GetService<ICartService>();

            try
            {
                Console.Clear();

                Console.Write(Labels.Feedback.EnterAction);

                string line;
                
                while (!Labels.Quit.Equals((line = Console.ReadLine().Trim())))
                {
                    string[] parameters = line.Split(' ');

                    Func<ICartService, Guid, Guid, uint, bool> action = null;

                    if (parameters.Length < 2 ||
                        !ActionsDictionary.TryGetValue(parameters[0], out action) ||
                        action == null)
                    {
                        Console.WriteLine(Labels.Feedback.InvalidAction);
                    }
                    else
                    {
                        int length = parameters.Length;

                        Guid cartId, productId;
                        uint amount;

                        Guid.TryParse(length > 1 ? parameters[1] : string.Empty, out cartId);
                        Guid.TryParse(length > 2 ? parameters[2] : string.Empty, out productId);
                        uint.TryParse(length > 3 ? parameters[3] : string.Empty, out amount);

                        bool result = action(cartService, cartId, productId, amount);

                        Console.Clear();

                        Console.WriteLine(
                            string.Format(Labels.Feedback.ResultAction,
                            Labels.Feedback.ResultToText(result)));

                        ICartInfo cart;

                        if (result && (cart = cartService.GetCartInfo(cartId)) != null)
                        {
                           Console.WriteLine(JsonConvert.SerializeObject(cart, Formatting.Indented));
                           Console.WriteLine();
                        }
                    }

                    Console.Write(Labels.Feedback.EnterAction);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Labels.Feedback.Error);

                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine(Labels.Feedback.Exit);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static class Labels
        {
            /// <summary>
            /// The quit
            /// </summary>
            public const string Quit = "q";

            /// <summary>
            /// 
            /// </summary>
            public static class Feedback
            {
                /// <summary>
                /// The enter action
                /// </summary>
                public const string EnterAction = 
                    "Please enter action one of the actions:\n\n" + 
                    "\t(c)reate\t(cart ID) \n" +
                    "\t(i)nfo\t\t(cart ID) \n" +
                    "\t(a)dd\t\t(cart ID)\t(Product ID)\t(Amount)\n" +
                    "\t(m)odify\t(cart ID)\t(Product ID)\t(Amount)\n" +
                    "\t(d)elete\t(cart ID)\t(Product ID)\n" + 
                    "\t(q)uit\n\n> ";

                /// <summary>
                /// The invalid action
                /// </summary>
                public const string InvalidAction = "Invalid action specification";

                /// <summary>
                /// The result action
                /// </summary>
                public const string ResultAction = "Action was {0}\n";

                /// <summary>
                /// The error
                /// </summary>
                public const string Error = "An error had occured";


                /// <summary>
                /// The exit
                /// </summary>
                public const string Exit = "Client quited";

                /// <summary>
                /// The result to text
                /// </summary>
                public static readonly Func<bool, string> ResultToText = m => m ? "Succesful" : "Unsuccessful";
            }
        }

        /// <summary>
        /// The actions dictionary
        /// </summary>
        private static IDictionary<string, Func<ICartService, Guid, Guid, uint, bool>> ActionsDictionary =
            new Dictionary<string, Func<ICartService, Guid, Guid, uint, bool>>
            {
                { "c", (service, cartID, productId, amount) => service.CreateCart(cartID) != null },
                { "i", (service, cartID, productId, amount) => service.GetCartInfo(cartID) != null },
                { "a", (service, cartID, productId, amount) => service.AddProduct(cartID, new ProductInfo() { ProductId = productId, Amount = amount }) },
                { "m", (service, cartID, productId, amount) => service.EditProduct(cartID, new ProductInfo() { ProductId = productId, Amount = amount }) },
                { "r", (service, cartID, productId, amount) => service.RemoveProduct(cartID, productId) },
                { "d", (service, cartID, productId, amount) => service.DeleteCart(cartID) }
            };
    }
}
