using System;
using System.Collections.Generic;

namespace Agenda_Mirzav3.AgendaMirzaDB;

public partial class SocialProfil
{
    public int IdSocialProfil { get; set; }

    public int ContactIdcontact { get; set; }

    public int SocialMediaIdSocialMedia { get; set; }

    public virtual Contact ContactIdcontactNavigation { get; set; } = null!;

    public virtual SocialMedium SocialMediaIdSocialMediaNavigation { get; set; } = null!;
}
