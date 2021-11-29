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

        private void btnGeneroMasMedallas_Click(object sender, EventArgs e)
        {
            StringBuilder generoMasMedallas = new StringBuilder();
            int medallasMasculino = 0;
            int medallasFemenino = 0;
            int medallasNB = 0;

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

            if (medallasMasculino >= medallasFemenino && medallasMasculino >= medallasNB)
            {
                generoMasMedallas.AppendLine($"El género con más medallas es el masculino, con {medallasMasculino} medallas.");
            }
            else if(medallasFemenino >= medallasMasculino && medallasFemenino >= medallasNB)
            {
                generoMasMedallas.AppendLine($"El género con más medallas es el femenino, con {medallasFemenino} medallas.");
            }
            else if (medallasNB >= medallasMasculino && medallasNB >= medallasFemenino)
            {
                generoMasMedallas.AppendLine($"El género con más medallas es el no binario, con {medallasNB} medallas.");
            }
            else 
            {
                generoMasMedallas.AppendLine("No hay socixs competitivos o nadie tiene medallas.");
            }

            MessageBox.Show(generoMasMedallas.ToString(), "Género con más medallas", MessageBoxButtons.OK);
                
        }

        private void btnSocixsCompetitivos_Click(object sender, EventArgs e)
        {
            StringBuilder deporteMasCompetitivo = new StringBuilder();
            int competidorxsNadadorxs = 0;
            int competidorxsFutbolistas = 0;
            int competidoresBox = 0;

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

            if (competidorxsNadadorxs >= competidorxsFutbolistas && competidorxsNadadorxs >= competidoresBox)
            {
                deporteMasCompetitivo.AppendLine($"El deporte con más socixs competitivos es Natación, con {competidorxsNadadorxs} socixs.");
            }
            else if (competidorxsFutbolistas >= competidorxsNadadorxs && competidorxsFutbolistas >= competidoresBox)
            {
                deporteMasCompetitivo.AppendLine($"El deporte con más socixs competitivos es el Futbol, con {competidorxsFutbolistas} socixs.");
            }
            else if (competidoresBox >= competidorxsFutbolistas && competidoresBox >= competidorxsNadadorxs)
            {
                deporteMasCompetitivo.AppendLine($"El deporte con más socixs competitivos es el Boxeo, con {competidoresBox} socixs.");
            }
            else
            {
                deporteMasCompetitivo.AppendLine("No hay socixs competitivos.");
            }

            MessageBox.Show(deporteMasCompetitivo.ToString(), "Deporte con más socixs competitivos", MessageBoxButtons.OK);
        }

        private void btnDeporteNinixs_Click(object sender, EventArgs e)
        {
            StringBuilder deporteConMasNinixs = new StringBuilder();
            int ninixsNadadorxs = 0;
            int ninixsFutbolistas = 0;
            int ninixsBox = 0;

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

            if (ninixsNadadorxs >= ninixsFutbolistas && ninixsNadadorxs >= ninixsBox)
            {
                deporteConMasNinixs.AppendLine($"El deporte con más socixs niñxs es Natación, con {ninixsNadadorxs} socixs.");
            }
            else if (ninixsFutbolistas >= ninixsNadadorxs && ninixsFutbolistas >= ninixsBox)
            {
                deporteConMasNinixs.AppendLine($"El deporte con más socixs niñxs es el Futbol, con {ninixsFutbolistas} socixs.");
            }
            else if (ninixsBox >= ninixsFutbolistas && ninixsBox >= ninixsNadadorxs)
            {
                deporteConMasNinixs.AppendLine($"El deporte con más socixs niñxs es el Boxeo, con {ninixsBox} socixs.");
            }
            else
            {
                deporteConMasNinixs.AppendLine("No hay socixs niñxs.");
            }

            MessageBox.Show(deporteConMasNinixs.ToString(), "Deporte con más niñxs", MessageBoxButtons.OK);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
