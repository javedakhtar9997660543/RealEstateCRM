using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminProject.PersistenceLayer.Entities.Entities
{
    public class Country
    {
        [Obsolete("For persistence only.")]
        public Country()
        {
        }

        public Country(string id, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("A valid Country is required.");
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("A valid id is required.");

            Name = name;
            Id = id;
        }

        public Country(string id, string name, string type)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("A valid Country is required.");
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("A valid id is required.");

            Name = name;
            Id = id;
            Type = type;
        }

        [Key]
        [Column("COUNTRYCODE")]
        [MaxLength(3)]
        public string Id { get; set; }

        [Column("COUNTRY")]
        public string Name { get; set; }

        [Column("COUNTRY_TID")]
        public int? NameTId { get; set; }

        [Column("COUNTRYADJECTIVE")]
        public string CountryAdjective { get; set; }

        [Column("POSTCODEFIRST")]
        public decimal? PostCodeFirst { get; set; }

        [Column("POSTCODELITERAL")]
        public string PostCodeLiteral { get; set; }

        [Column("POSTCODELITERAL_TID")]
        public int? PostCodeLiteralTId { get; set; }

        [Column("POSTALNAME")]
        public string PostalName { get; set; }

        [Column("STATEABBREVIATED")]
        public decimal? StateAbbreviated { get; set; }

        [Column("ADDRESSSTYLE")]
        [ForeignKey("AddressStyle")]
        public int? AddressStyleId { get; set; }

        public virtual TableCode AddressStyle { get; set; }

        [Column("NAMESTYLE")]
        [ForeignKey("NameStyle")]
        public int? NameStyleId { get; set; }

        public virtual TableCode NameStyle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag")]
        [Column(TypeName = "decimal(9,4)")]
        public decimal AllMembersFlag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        [Column("RECORDTYPE")]
        public string Type { get; set; }

        [Column("ALTERNATECODE")]
        public string AlternateCode { get; set; }

        [Column("COUNTRYABBREV")]
        public string Abbreviation { get; set; }

        [Column("INFORMALNAME")]
        public string InformalName { get; set; }

        [Column("ISD")]
        public string IsdCode { get; set; }

        [Column("PRIORARTFLAG")]
        public bool? ReportPriorArt { get; set; }

        [Column("NOTES")]
        public string Notes { get; set; }

        [Column("DATECOMMENCED")]
        public DateTime? DateCommenced { get; set; }

        [Column("DATECEASED")]
        public DateTime? DateCeased { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "WorkDay")]
        [Column("WORKDAYFLAG")]
        public short? WorkDayFlag { get; set; }

        public virtual ICollection<State> States { get; set; } = new Collection<State>();

        [Column("INFORMALNAME_TID")]
        public int? InformalNameTId { get; set; }

        [Column("COUNTRYADJECTIVE_TID")]
        public int? CountryAdjectiveTId { get; set; }

        [Column("POSTALNAME_TID")]
        public int? PostalNameTId { get; set; }

        [Column("NOTES_TID")]
        public int? NotesTId { get; set; }

        [Column("STATELITERAL")]
        public string StateLabel { get; set; }

        [Column("STATELITERAL_TID")]
        public int? StateLabelTId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag")]
        [Column(TypeName = "decimal(9,4)")]
        public decimal? PostCodeAutoFlag { get; set; }

        [Column("POSTCODESEARCHCODE")]
        [ForeignKey("PostCodeSearchCode")]
        public int? PostCodeSearchCodeId { get; set; }

        public virtual TableCode PostCodeSearchCode { get; set; }

        [Column("DEFAULTTAXCODE")]
        [ForeignKey("DefaultTaxRate")]
        public string DefaultTaxId { get; set; }

        public virtual TaxRate DefaultTaxRate { get; set; }

        [Column("DEFAULTCURRENCY")]
        [ForeignKey("DefaultCurrency")]
        public string DefaultCurrencyId { get; set; }

        public virtual Currency DefaultCurrency { get; set; }

        [Column("REQUIREEXEMPTTAXNO", TypeName = "decimal(9,4)")]
        public decimal? TaxNoMandatory { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class CountryGroup
    {

        [Obsolete("For persistence only.")]
        public CountryGroup()
        {
        }

        public CountryGroup(string id, string countryCode)
        {
            if (countryCode == null) throw new ArgumentNullException("countryCode");

            Id = id ?? throw new ArgumentNullException("id");
            MemberCountry = countryCode;
        }

        public CountryGroup(Country groupCountry, Country memberCountry)
        {
            if (groupCountry == null) throw new ArgumentNullException("groupCountry");
            if (memberCountry == null) throw new ArgumentNullException("memberCountry");

            Id = groupCountry.Id;
            MemberCountry = memberCountry.Id;
        }

        [Key]
        [Column("TREATYCODE", Order = 0)]
        public string Id { get; protected set; }

        [Key]
        [Column("MEMBERCOUNTRY", Order = 1)]
        public string MemberCountry { get; protected set; }

        [Column("PROPERTYTYPES")]
        public string PropertyTypes { get; set; }

        [Column("DATECOMMENCED")]
        public DateTime? DateCommenced { get; set; }

        [Column("DATECEASED")]
        public DateTime? DateCeased { get; set; }

        [Column("ASSOCIATEMEMBER", TypeName = "decimal(9,4)")]
        public decimal? AssociateMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flag")]
        [Column("DEFAULTFLAG", TypeName = "decimal(9,4)")]
        public decimal? DefaultFlag { get; set; }

        [Column("PREVENTNATPHASE")]
        public bool? PreventNationalPhase { get; set; }

        [Column("FULLMEMBERDATE")]
        public DateTime? FullMembershipDate { get; set; }

        [Column("ASSOCIATEMEMBERDATE")]
        public DateTime? AssociateMemberDate { get; set; }
    }

    public class State
    {
        public State() { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public State(string code, string name, Country country)
        {
            if (country == null) throw new ArgumentNullException(nameof(country));

            Code = code;
            Name = name;
            Country = country;
            CountryCode = country.Id;
        }

        public State(string code, string name, string countryCode)
        {
            Code = code;
            Name = name;
            CountryCode = countryCode;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        [Column("COUNTRYCODE")]
        public string CountryCode { get; set; }

        [Column("STATE")]
        public string Code { get; set; }

        [Column("STATENAME")]
        public string Name { get; set; }

        [Column("STATENAME_TID")]
        public int? NameTId { get; set; }

        public virtual Country Country { get; protected set; }
    }

}
