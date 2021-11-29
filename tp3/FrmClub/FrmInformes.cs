using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmClub
{
    public partial class FrmInformes : Form
    {
        List<Socix> listaSocixs = new List<Socix>();
        public FrmInformes(List<Socix> lista)
        {
            InitializeComponent();
            listaSocixs = lista;
        }

        private void btnMedallasSegunGenero_Click(object sender, EventArgs e)
        {
            StringBuilder generoMedallas = new StringBuilder();
            float medallasMasculino = 0;
            float medallasFemenino = 0;
            float medallasNB = 0;
            float totalMedallas = 0;

            foreach (Socix socix in this.listaSocixs)
            {
                if (socix.TipoSocix == ETipoSocix.Competitivo)
                {
                    switch (socix.Genero)
                    {
                        case EGenero.Masculino:
                            medallasMasculino += socix.CantidadMedallas;
                            break;
                        case EGenero.Femenino:
                            medallasFemenino += socix.CantidadMedallas;
                            break;
                        default:
                            medallasNB += socix.CantidadMedallas;
                            break;
                    }
                }                                  
            }

            totalMedallas = medallasFemenino + medallasMasculino + medallasNB;

            medallasMasculino = medallasMasculino * totalMedallas / 100;
            medallasFemenino = medallasFemenino * totalMedallas / 100;
            medallasNB = medallasNB * totalMedallas / 100;


            generoMedallas.AppendLine($"El género masculino posee el %{medallasMasculino} de medallas.");

            generoMedallas.AppendLine($"El género femenino posee el  %{medallasFemenino} de medallas.");

            generoMedallas.AppendLine($"El género no binario posee el %{medallasNB} de medallas.");                                    

            MessageBox.Show(generoMedallas.ToString(), "Porcentaje de medallas según género", MessageBoxButtons.OK);
                
        }

        private void btnSocixsCompetitivos_Click(object sender, EventArgs e)
        {
            StringBuilder deporteMasCompetitivo = new StringBuilder();
            float competidorxsNadadorxs = 0;
            float competidorxsFutbolistas = 0;
            float competidoresBox = 0;
            float totalCompetidores;

            foreach (Socix socix in this.listaSocixs)
            {
                if (socix.TipoSocix == ETipoSocix.Competitivo)
                {
                    if (socix.ValorCuota == ECuota.NinixsNatacion || socix.ValorCuota == ECuota.AdultxsNatacion)
                    {
                        competidorxsNadadorxs++;

                    }
                    else if (socix.ValorCuota == ECuota.NinixsFutbol || socix.ValorCuota == ECuota.AdultxsFutbol)
                    {
                        competidorxsFutbolistas++;
                    }
                    else
                    {
                        competidoresBox++;
                    }
                }
            }

            totalCompetidores = competidoresBox + competidorxsFutbolistas + competidorxsNadadorxs;

            competidoresBox = competidoresBox * totalCompetidores / 100;
            competidorxsNadadorxs = competidorxsNadadorxs * totalCompetidores / 100;
            competidorxsFutbolistas = competidorxsFutbolistas * totalCompetidores / 100;


            deporteMasCompetitivo.AppendLine($"El porcentaje de socixs competitivos de Natación es de %{competidorxsNadadorxs}.");
        
            deporteMasCompetitivo.AppendLine($"El porcentaje de socixs competitivos de Futbol es de %{competidorxsFutbolistas}.");
      
            deporteMasCompetitivo.AppendLine($"El porcentaje de socixs competitivos de Boxeo es de % {competidoresBox}.");       

            MessageBox.Show(deporteMasCompetitivo.ToString(), "Socixs competitivos por deporte", MessageBoxButtons.OK);
        }

        private void btnDeporteNinixs_Click(object sender, EventArgs e)
        {
            StringBuilder deporteConMasNinixs = new StringBuilder();
            float ninixsNadadorxs = 0;
            float ninixsFutbolistas = 0;
            float ninixsBox = 0;
            float totalNinixs;

            foreach (Socix socix in this.listaSocixs)
            {
                if (socix.Edad <= 12)
                {
                    if (socix.ValorCuota == ECuota.NinixsNatacion || socix.ValorCuota == ECuota.AdultxsNatacion)
                    {
                        ninixsNadadorxs++;

                    }
                    else if (socix.ValorCuota == ECuota.NinixsFutbol || socix.ValorCuota == ECuota.AdultxsFutbol)
                    {
                        ninixsFutbolistas++;
                    }
                    else
                    {
                        ninixsBox++;
                    }
                }
            }

            totalNinixs = ninixsBox + ninixsFutbolistas + ninixsNadadorxs;
            ninixsBox = ninixsBox * totalNinixs / 100;
            ninixsFutbolistas = ninixsFutbolistas * totalNinixs / 100;
            ninixsNadadorxs = ninixsNadadorxs * totalNinixs / 100; 

            deporteConMasNinixs.AppendLine($"El porcentaje de socixs niñxs en Natación es de %{ninixsNadadorxs}.");
            deporteConMasNinixs.AppendLine($"El porcentaje de socixs niñxs en Boxeo es de %{ninixsBox}");
            deporteConMasNinixs.AppendLine($"El porcentaje de socixs niñxs en Futbol es de %{ninixsBox}");


            MessageBox.Show(deporteConMasNinixs.ToString(), "Porcentaje de ninixs según deporte", MessageBoxButtons.OK);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
