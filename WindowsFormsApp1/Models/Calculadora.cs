using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Calculadora
    {
        public decimal valorParcelasVencidas { get; set; } = 0;
        public decimal _juros = 0;
        public decimal IOF { get; set; } = 0;
        public decimal GCA { get; set; } = 0;
        private decimal _valorJurosPagar = 0;
        private decimal _pencentualDescontoConcedido = 0;
        public decimal _valorDescontoConcedidoJuros = 0;
        public decimal _percentualComissao = 5;
        private decimal _valorComissao = 0;
        public decimal _valorDescontoConcedidoHO = 0;
        private decimal _valorTotalParcelasVencidas = 0;
        public decimal valorParcelasVencerSemDesconto { get; set; } = 0;

        public decimal valorParcelasVencer { get; set; } = 0;
        private decimal _valorDescontoConcedidoQuitacao = 0;
        private decimal _valorQuitacao = 0;
        public decimal valorDevPremios { get; set; } = 0;
        private decimal _valorTotal = 0;

        public decimal juros
        {
            set
            {
                _juros = value;
                _valorJurosPagar = value;
            }
            get { return _juros; }
        }


        public decimal pencentualDescontoConcedido
        {
            get
            {
                this._pencentualDescontoConcedido = juros != 0?(valorDescontoConcedidoJuros / juros) * 100 : 0;
                return _pencentualDescontoConcedido;
            }
        }

        public decimal valorJurosPagar
        {
            set
            {
                if (value > juros)
                {
                    _valorJurosPagar = juros;
                }
                else if (value < 0)
                {
                    _valorJurosPagar = 0;
                }
                else
                {
                    _valorJurosPagar = value;
                }
            }
            get { return _valorJurosPagar; }
        }

        public decimal valorDescontoConcedidoJuros
        {
            get
            {
                this._valorDescontoConcedidoJuros = (juros - valorJurosPagar);
                return _valorDescontoConcedidoJuros;
            }
        }

        public decimal valorComissao
        {
            get
            {
                this._valorComissao = (valorParcelasVencidas + valorJurosPagar) * (percentualComissao/100);
                return _valorComissao;
            }
        }

        public decimal percentualComissao
        {
            set
            {
                if (value > 5)
                {
                    _percentualComissao = 5;
                }
                else if (value < 0)
                {
                    _percentualComissao = 0;
                }
                else
                {
                    _percentualComissao = value;
                }
            }
            get { return _percentualComissao; }
        }

        public decimal valorTotalParcelasVencidas
        {
            get
            {
                this._valorTotalParcelasVencidas = (valorParcelasVencidas + IOF + GCA + valorComissao + valorJurosPagar);
                return _valorTotalParcelasVencidas;
            }
        }

        public decimal valorDescontoConcedidoHO
        {
            get
            {
                if (percentualComissao < 5)
                {
                    _valorDescontoConcedidoHO = ((valorParcelasVencidas + valorJurosPagar) * ((decimal)0.05) ) - (valorComissao);
                }
                else
                {
                    _valorDescontoConcedidoHO = 0;
                }
                return _valorDescontoConcedidoHO;
            }
        }

        public decimal valorQuitacao
        {
            get
            {
                this._valorQuitacao = (valorParcelasVencidas + valorParcelasVencer) - (valorDevPremios);
                return _valorQuitacao;
            }
        }

        
        public decimal valorDescontoConcedidoQuitacao
        {
            get
            {
                this._valorDescontoConcedidoQuitacao = (valorDescontoConcedidoJuros) + (valorDescontoConcedidoHO)+(valorParcelasVencerSemDesconto - valorParcelasVencer);
                return _valorDescontoConcedidoQuitacao;
            }
        }

        public decimal valorTotal
        {
            get
            {
                this._valorTotal = (valorTotalParcelasVencidas + valorParcelasVencer) - (valorDevPremios);
                return _valorTotal;
            }
        }

    }
}
