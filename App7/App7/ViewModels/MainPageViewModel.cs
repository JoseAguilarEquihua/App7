using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App7.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        Command _encriptaCommand;
        private string _nombre;
        private string _apellidoPaterno;
        private string _apellidoMaterno;
        private string _nombreUsuario;
        private string _contrasenia;
        private string _nombreEncriptado;
        private string _apellidoPaternoEncriptado;
        private string _apellidoMaternoEncriptado;
        private string _nombreUsuarioEncriptado;
        private string _contraseniaEncriptada;
        private bool send;

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(DatosEncriptados));
            }
        }

        public string ApellidoPaterno
        {
            get => _apellidoPaterno;
            set
            {
                _apellidoPaterno = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(DatosEncriptados));
            }
        }

        public string ApellidoMaterno
        {
            get => _apellidoMaterno;
            set
            {
                _apellidoMaterno = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(DatosEncriptados));
            }
        }

        public string NombreUsuario
        {
            get => _nombreUsuario;
            set
            {
                _nombreUsuario = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(DatosEncriptados));
            }
        }

        public string Contrasenia
        {
            get => _contrasenia;
            set
            {
                _contrasenia = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(DatosEncriptados));
            }
        }

        public bool Send
        {
            get => send;
            set
            {
                send = value;
                OnPropertyChanged();
            }
        }

        public string DatosEncriptados
        {
            get => string.Format("{{'nombre':'{0}', 'apellidoPaterno':'{1}', 'apellidoMaterno':'{2}', 'nombreUsuario':'{3}', 'contraseña':'{4}'}}", _nombreEncriptado, _apellidoPaternoEncriptado, _apellidoMaternoEncriptado, _nombreUsuarioEncriptado, _contraseniaEncriptada);            
        }

        public Command EncriptaCommand
        {
            get => _encriptaCommand ?? (_encriptaCommand = new Command(EncriptaAction));
        }

        private void EncriptaAction()
        {
            _nombreEncriptado = Encriptar(_nombre);
            _apellidoPaternoEncriptado = Encriptar(_apellidoPaterno);
            _apellidoMaternoEncriptado = Encriptar(_apellidoMaterno);
            _nombreUsuarioEncriptado = Encriptar(_nombreUsuario);
            _contraseniaEncriptada = Encriptar(_contrasenia);
            Send = true;
            OnPropertyChanged(nameof(DatosEncriptados));
            
        }

        public static string Encriptar(string dato)
        {
            
            string result = string.Empty;
            if (!string.IsNullOrEmpty(dato))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(dato);
                result = Convert.ToBase64String(byteArray);
            }
            return result;
        }
    }
}
