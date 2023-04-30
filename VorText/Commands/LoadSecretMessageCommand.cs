using MVVMEssentials.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VorText.Queries;
using VorText.ViewModels;
using VorTextShared.Core.Responses;

namespace VorText.Commands
{
    class LoadSecretMessageCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly IGetSecretMessageQuery _getSecretMessageQuery;

        public LoadSecretMessageCommand(HomeViewModel homeViewModel, IGetSecretMessageQuery getSecretMessageQuery)
        {
            _homeViewModel = homeViewModel;
            _getSecretMessageQuery = getSecretMessageQuery;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            try
            {
                SecretMessageResponse secretMessageResponse = await _getSecretMessageQuery.Execute();

                _homeViewModel.SecretMessage = secretMessageResponse.Message;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load secret message!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
