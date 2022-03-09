using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MvvmToolkitTemplate.ViewModels {
    public class ExceptionWindowViewModel : ObservableObject, IDisposable {

        public void Initialize() {
        }
        #region Exception変更通知プロパティ
        private Exception _Exception;

        public Exception Exception {
            get => _Exception;
            set => SetProperty(ref _Exception, value);
        }
        #endregion



        #region ErrorText変更通知プロパティ

        public string ErrorText {
            get {
                if (this.Exception is AggregateException) {
                    return string.Join("\r\n\r\n", ((AggregateException)this.Exception).InnerExceptions.Select(x => $"{x.Message}\r\n\r\n{x.StackTrace}"));
                } else {
                    return $"{this.Exception.Message}\r\n\r\n{this.Exception.StackTrace}";
                }
            }
        }
        #endregion


        #region ContinueCommand
        private RelayCommand _ContinueCommand;

        public RelayCommand ContinueCommand {
            get {
                if (_ContinueCommand == null) {
                    _ContinueCommand = new RelayCommand(Continue, CanContinue);
                }
                return _ContinueCommand;
            }
        }

        public bool CanContinue() {
            return this.EnableContinue;
        }

        public void Continue() {
            this.DialogResult = true;
        }
        #endregion



        #region QuitCommand
        private RelayCommand _QuitCommand;

        public RelayCommand QuitCommand {
            get {
                if (_QuitCommand == null) {
                    _QuitCommand = new RelayCommand(Quit);
                }
                return _QuitCommand;
            }
        }

        public void Quit() {
            this.DialogResult = false;
        }
        #endregion


        #region DialogResult変更通知プロパティ
        private bool? _DialogResult;

        public bool? DialogResult {
            get => _DialogResult;
            private set => SetProperty(ref _DialogResult, value);
        }
        #endregion



        #region EnableContinue変更通知プロパティ
        private bool _EnableContinue;

        public bool EnableContinue {
            get => _EnableContinue;
            set => SetProperty(ref _EnableContinue, value);
        }

        private bool disposedValue;
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
        // ~ExceptionWindowViewModel()
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
