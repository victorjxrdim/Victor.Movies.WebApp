using System.ComponentModel;

namespace Victor.Movies.DataAccess.Enums
{
    public enum GeneroEnum
    {
        [Description("Drama")]
        DRAMA = 1,
        [Description("Ação")]
        ACAO = 2,
        [Description("Comedia")]
        COMEDIA = 3,
        [Description("Terror")]
        TERROR = 4,
        [Description("Ficção Cientifica")]
        FICCAO_CIENTIFICA = 5,
        [Description("Romance")]
        ROMANCE = 6,
        [Description("Aventura")]
        AVENTURA = 7,
        [Description("Documentário")]
        DOCUMENTARIO = 8,
        [Description("Animação")]
        ANIMACAO = 9,
        [Description("Fantasia")]
        FANTASIA = 10,
    }
}
