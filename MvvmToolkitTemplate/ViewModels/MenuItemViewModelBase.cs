using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmToolkitTemplate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MvvmToolkitTemplate.ViewModels {
    public class MenuItemViewModelBase : ObservableObject, MahApps.Metro.Controls.IHamburgerMenuItemBase, IDisposable {
        public delegate void ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);
        public event ErrorOccurredEventHandler ErrorOccurred = delegate { };
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        public event MessageEventHandler Message = delegate { };
        protected void OnErrorOccurred(ErrorOccurredEventArgs e) {
            ErrorOccurred(this, e);
        }
        protected void OnMessage(MessageEventArgs e) {
            Message(this, e);
        }
        public MenuItemViewModelBase(MainWindowViewModel parent) : base() {
            this.MainViewModel = parent;
        }
        public MainWindowViewModel MainViewModel {
            get;
        }

        #region Icon変更通知プロパティ
        private object _Icon;

        public object Icon {
            get => _Icon;
            set => SetProperty(ref _Icon, value);
        }
        #endregion


        #region Label変更通知プロパティ
        private object _Label;

        public object Label {
            get => _Label;
            set => SetProperty(ref _Label, value);
        }
        #endregion


        #region ToolTip変更通知プロパティ
        private object _ToolTip;

        public object ToolTip {
            get => _ToolTip;
            set => SetProperty(ref _ToolTip, value);
        }
        #endregion


        #region IsVisible変更通知プロパティ
        private bool _IsVisible;
        private bool disposedValue;

        public bool IsVisible {
            get => _IsVisible;
            set => SetProperty(ref _IsVisible, value);
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~MenuItemViewModelBase()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose() {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
