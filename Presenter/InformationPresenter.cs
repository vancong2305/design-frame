using System;
using DesignFrame.Model;
using DesignFrame.View.OverView;

namespace DesignFrame.Presenter
{
    internal class InformationPresenter
    {
        private readonly Information model;
        private readonly IInformation view;

        public InformationPresenter(IInformation _view, Information _model)
        {
            model = _model;
            view = _view;

            // Subscribe to view events
            view.OnNameChanged += HandleNameChange;
            view.OnClassChanged += HandleClassChange;
            view.OnLevelChanged += HandleLevelChange;
            view.OnAvatarChanged += HandleAvatarChange;
            view.OnGenChanged += HandleGenChange;

        }

        // Handle view events (user input)
        private void HandleNameChange(object sender, EventArgs e)
        {
        }

        private void HandleClassChange(object sender, EventArgs e)
        {
        }

        private void HandleLevelChange(object sender, EventArgs e)
        {
        }

        private void HandleAvatarChange(object sender, EventArgs e)
        {
        }

        private void HandleGenChange(object sender, EventArgs e)
        {
        }

        // Additional methods for handling logic
        public void Initialize()
        {
            // Optionally load initial data from the model into the view
            view.Name = model.Name;
            view.Class = model.Class;
            view.Level = model.Level;
            view.Avatar = model.Avatar;
            view.Gen = model.Gen;
        }
    }
}
