using MainSpace.MainMenu.Models;
using MainSpace.MainMenu.Views;

namespace MainSpace.MainMenu.Presenters
{
    public sealed class QuestionListPresenter
    {
        private readonly QuestionListView _listView;
        private readonly QuestionListModel _listModel;

        public QuestionListPresenter(QuestionListView view, QuestionListModel model)
        {
            _listView = view;
            _listModel = model;


        }


    }
}
