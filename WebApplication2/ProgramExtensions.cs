using WebApplication2.Data;
using WebApplication2.Repository;

namespace WebApplication2;

public static class ProgramExtensions
{
    public static async Task InitDb(this WebApplication application)
    {
        var scope = application.Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IHistoricalFiguresRepository>();
        var list = new List<HistoricalFigure>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Гаджи́",
                Surname = "Зейналабдин",
                ShortImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f8/Haji_Zeynalabdin_Taghiyev.jpg",
                Occupation =
                    "азербайджанский промышленник, общественно-политический деятель, миллионер и меценат, " +
                    "почётный гражданин, благотворитель и филантроп",
                FullDescription =
                    """
                Тагиев являлся одним из пионеров бакинской нефтяной промышленности. Основанной в 1873 году фирме «Г. З. А. Тагиев» в середине 1890-ых принадлежали земли и промыслы на Биби-Эйбатской площади, нефтехранилища, керосиновый и масляные заводы, а также нефтеналивные суда на Каспийском море[16]. Также Тагиев владел текстильной фабрикой, рыбными промыслами, торговыми фирмами, купеческим банком и пр. Тагиев был наиболее известным среди крупных мусульман-нефтепромышленников Баку и самым богатым мусульманином в Российской империи. Его капитал составлял около 16 миллионов рублей[17], а к концу 1917 года, по неполным данным, — 30 миллионов рублей[2]. Тагиев сыграл выдающуюся роль в развитии экономического потенциала Кавказа на рубеже XIX—XX вв.[10][⇨]
                Тагиев был одним из наиболее известных нефтяных баронов–филантропов[15].Он был главой благотворительного
                просветительского общества «Нешри-Маариф» (азерб.)рус.и членом Общества просвещения мусульман Дагестана.
                В 1917 году участвовал в финансировании Союза объединенных горцев.Также Тагиев основал в Баку театр,
                в котором ставились национальные пьесы и оперы[18].Помимо этого Тагиев финансировал несколько печатных
                изданий, включая газеты «Каспий» и «Хайят»,
                организовал и издал первый перевод Корана на азербайджанский язык,
                а также финансировал строительство Баку-Шолларского водопровода.[⇨]
                Тагиев материально поддерживал целый ряд начальных школ в Бакинской, Елизаветпольской,
                Эриванской губерниях, оказывал помощь в финансировании учреждений образования в Грузии,
                на Северном Кавказе, в Поволжье, Польше, Иране[18],
                тратил средства на подготовку национальных кадров[2].В 1901 году он основал и финансировал училище для
                девушек-мусульманок в Баку,
                а в 1913 году основал при училище педагогические курсы[18].В своём письме Николаю II Д.И.Менделеев
                писал, что Тагиев жертвует «много на школы,
                чтобы оживить и возвысить свой родной город»[16].Тагиев внёс значительный вклад в развитие образования в
                Азербайджане[15].[⇨]
                После установления в Азербайджане советской власти, все предприятия Тагиева были национализированы[19].
                """,
                DateOfBirth = new DateOnly(1823, 1, 1),
                DateOfDeath = new DateOnly(1924, 9, 1),
                ShortDescription =
                    "Азербайджанский промышленник, общественно-политический деятель, миллионер и меценат, почётный гражданин, благотворитель и филантроп",
                FullImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f8/Haji_Zeynalabdin_Taghiyev.jpg"
            }
        };
        await repository.AddFigureAsync(list[0]);
    }
}