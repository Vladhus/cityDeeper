using App2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace App2.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        NewTravelVM viewModel;

        public PostCommand(NewTravelVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;
            if (post != null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                {
                    return false;
                }
                if (post.Venue != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            viewModel.PublishPost(post);
        }
    }
}
