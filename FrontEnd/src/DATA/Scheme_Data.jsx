const SchemesData = {
    individual: {
      title: "All Individual Plan",
      question: "Why Individual Health Plan?",
      answer: "As the name suggests, an individual plan is a type of medical insurance offering coverage, benefits, and security against medical emergencies to a single policyholder. An individual insurance policy acts as a personal safeguard against any expenses arising due to emergency hospitalization, accidents, or other ailments. As an individual, you can customize the benefits of an individual mediclaim policy while enjoying a pocket-friendly premium.",
      blockdata: [
        {
          title: "People At Higher Risk",
          description: "People who are susceptible to increased health risks owing to an unhealthy lifestyle and stressful occupations.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M12 7a5 5 0 11-5 5 5 5 0 015-5zm-1 7H8v-1a1 1 0 011-1h2a1 1 0 011 1v1zm4-3v4a1 1 0 01-1 1H6a1 1 0 01-1-1V9a1 1 0 011-1h1v1.142A6.978 6.978 0 0012 8a6.978 6.978 0 004-1.142V8h1a1 1 0 011 1z" />
            </svg>
          ),
        },
        {
          title: "Aging Parents",
          description: "Elderly parents and family members with specific medical conditions like diabetes, hypertension.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M14 10a3 3 0 11-3 3 3 3 0 013-3zm6-2a6 6 0 00-12 0v5a6 6 0 0012 0v-5zM5.5 11.5A3.5 3.5 0 009 15h6a3.5 3.5 0 003.5-3.5V9H5.5v2.5zM12 2.5A9.5 9.5 0 002.5 12 9.5 9.5 0 0012 21.5 9.5 9.5 0 0021.5 12 9.5 9.5 0 0012 2.5zm0 17a7.5 7.5 0 110-15 7.5 7.5 0 010 15z" />
            </svg>
          ),
        },
        {
          title: "Uninsured Individuals",
          description: "If you are an uninsured individual while your family is already insured under a policy, you should get a personal health cover.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M3 3h18v18H3V3zm2 2v14h14V5H5zm7 2h2v2h-2V7zm0 4h2v2h-2v-2zm-4 0h2v2H8v-2zm0-4h2v2H8V7zm-4 0h2v2H4V7z" />
            </svg>
          ),
        },
      ],
    },
  
    family: {
      title: "All Family Plans",
      question: "Why Family Health Plan?",
      answer: "A family health plan offers coverage to the entire family under a single policy, providing financial protection against medical emergencies for all members. This type of plan is ideal for families looking for comprehensive coverage at a lower premium compared to individual policies for each member. It covers a wide range of medical expenses and provides benefits tailored to family needs.",
      blockdata: [
        {
          title: "Families with Young Children",
          description: "Families with young children who need coverage for regular medical check-ups, vaccinations, and emergencies.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M13 2a5 5 0 00-5 5v6a5 5 0 00-5 5v3a1 1 0 001 1h16a1 1 0 001-1v-3a5 5 0 00-5-5V7a5 5 0 00-5-5zm-1 12a2 2 0 100-4 2 2 0 000 4zm6 2H7v-1a4 4 0 018 0v1zm-4-8a3 3 0 00-3 3v2a3 3 0 00-3 3v2h14v-2a3 3 0 00-3-3v-2a3 3 0 00-3-3z" />
            </svg>
          ),
        },
        {
          title: "Families with Multiple Members",
          description: "Families with multiple members who want to simplify insurance management by having a single policy covering everyone.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M11 9a3 3 0 016 0v2a3 3 0 01-6 0V9zm7-3H6a2 2 0 00-2 2v2h16V8a2 2 0 00-2-2zM5 16a3 3 0 00-3 3v3a1 1 0 001 1h2v-4H3v-1a1 1 0 011-1h2v-2H5zm15 0a3 3 0 00-3 3v1h2v4h2a1 1 0 001-1v-3a3 3 0 00-3-3zm-7 1a3 3 0 00-3 3v1h6v-1a3 3 0 00-3-3z" />
            </svg>
          ),
        },
        {
          title: "Families Seeking Comprehensive Coverage",
          description: "Families looking for extensive medical coverage that includes outpatient consultations, hospitalization, and preventive care.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M12 2a9.5 9.5 0 00-9.5 9.5A9.5 9.5 0 0012 21a9.5 9.5 0 009.5-9.5A9.5 9.5 0 0012 2zm0 17a7.5 7.5 0 110-15 7.5 7.5 0 010 15zM7 9h10v2H7V9zm0 4h10v2H7v-2z" />
            </svg>
          ),
        },
      ],
    },
  
    corporate: {
      title: "Corporate Health Plans",
      question: "Why Corporate Health Plan?",
      answer: "Corporate health plans are designed for businesses to provide health insurance coverage to their employees. These plans offer a range of benefits including medical expenses, wellness programs, and preventive care. Corporate plans help in attracting and retaining talent by ensuring employees have access to quality healthcare and enhancing overall productivity.",
      blockdata: [
        {
          title: "Businesses with Large Workforce",
          description: "Companies with a large workforce looking to provide health insurance benefits as part of their employee welfare program.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M12 3v3a4 4 0 00-4 4H3v6h5v-1a4 4 0 018 0v1h5V9h-5a4 4 0 00-4-4V3h-2z" />
            </svg>
          ),
        },
        {
          title: "Companies with High Attrition Rate",
          description: "Businesses aiming to reduce employee turnover by offering comprehensive health benefits to improve job satisfaction and loyalty.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M12 3v6a4 4 0 00-4 4H3v6h5v-1a4 4 0 018 0v1h5V13h-5a4 4 0 00-4-4V3h-2z" />
            </svg>
          ),
        },
        {
          title: "Organizations Focused on Employee Wellness",
          description: "Organizations that prioritize employee health and wellness, offering preventive and emergency medical care as part of their corporate benefits package.",
          svg: (
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="w-6 h-6">
              <path d="M12 2a9.5 9.5 0 00-9.5 9.5A9.5 9.5 0 0012 21a9.5 9.5 0 009.5-9.5A9.5 9.5 0 0012 2zm0 17a7.5 7.5 0 110-15 7.5 7.5 0 010 15zM9 12h6v2H9v-2z" />
            </svg>
          ),
        },
      ],
    },
  };
  
  export default SchemesData;

  export const SchemeData = {
    individual: [
      {
        schemeId: 1,
        schemeName: "Individual Basic Plan",
        schemeDescription: "The Individual Basic Plan offers essential health coverage for individuals at an affordable premium. This plan includes coverage for hospitalization, surgery, and emergency care. It is designed for those seeking fundamental protection against medical expenses.",
        coverageAmount: 500000,
        schemeType: "Individual",
        basePremiumAmount: 5000,
        schemeStartedAt: new Date(2020, 0, 1),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 5,
        coverageYears: 10,
        routeTitle: "individual-basic-plan" // This field is used for routing
      },
      {
        schemeId: 2,
        schemeName: "Individual Premium Plan",
        schemeDescription: "The Individual Premium Plan provides extensive health coverage for individuals, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for those who want a higher level of health security and comprehensive medical benefits.",
        coverageAmount: 1000000,
        schemeType: "Individual",
        basePremiumAmount: 10000,
        schemeStartedAt: new Date(2021, 5, 15),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 7,
        coverageYears: 15,
        routeTitle: "individual-premium-plan" // This field is used for routing
      },
      {
        schemeId: 3,
        schemeName: "Individual Elite Plan",
        schemeDescription: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Assumenda voluptatem totam similique nobis dolore in, velit consectetur perspiciatis vero quas. Esse deleniti commodi perferendis officia saepe natus, quas dolor. Perspiciatis iusto nam optio quo natus amet velit explicabo quod, officia adipisci quia ipsum odio deleniti, fugiat esse illum tenetur obcaecati corporis quasi quibusdam dolorum laboriosam in. Numquam autem temporibus molestiae delectus sequi cupiditate suscipit natus facere enim dolorum sed eaque voluptas repellendus officiis et doloremque totam pariatur, quae, non amet explicabo. Maxime, magni! Ea voluptate aspernatur impedit vitae quasi necessitatibus. Ex, commodi quaerat. Dolor deleniti eos amet non. Optio minima quos incidunt recusandae eveniet, consequuntur earum quam nesciunt tenetur deserunt voluptas tempora ipsa omnis ipsam a iusto rerum, obcaecati aut nulla quo, blanditiis perferendis? Quam quo alias error possimus impedit sapiente commodi earum quaerat? Quas natus rem voluptate, at nostrum ut itaque voluptatibus porro velit labore consequatur obcaecati et nulla nihil cum, provident ratione iusto esse iure! Porro, totam cumque molestias officia minus vel molestiae, quod alias excepturi pariatur voluptates quae, cupiditate voluptatem fugit delectus. Ipsa temporibus similique odit veniam quo, cupiditate nesciunt dignissimos consequuntur aperiam, eveniet facilis recusandae voluptates nulla quaerat mollitia labore quae! Sapiente odio deserunt eum suscipit.",
        coverageAmount: 2000000,
        schemeType: "Individual",
        basePremiumAmount: 20000,
        schemeStartedAt: new Date(2022, 2, 10),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 10,
        coverageYears: 20,
        routeTitle: "individual-elite-plan" // This field is used for routing
      }
    ],
  
    corporate: [
      {
        schemeId: 4,
        schemeName: "Corporate Standard Plan",
        schemeDescription: "The Corporate Standard Plan offers essential health coverage for employees of small and medium-sized businesses. It includes hospitalization and emergency care benefits, providing basic protection to ensure the well-being of your workforce.",
        coverageAmount: 1000000,
        schemeType: "Corporate",
        basePremiumAmount: 15000,
        schemeStartedAt: new Date(2019, 4, 20),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 5,
        coverageYears: 10,
        routeTitle: "corporate-standard-plan" // This field is used for routing
      },
      {
        schemeId: 5,
        schemeName: "Corporate Comprehensive Plan",
        schemeDescription: "The Corporate Comprehensive Plan provides extensive health coverage for employees, including benefits for outpatient treatments, preventive care, and specialist consultations. This plan is designed for businesses that want to offer their employees a higher level of health security and comprehensive medical benefits.",
        coverageAmount: 2500000,
        schemeType: "Corporate",
        basePremiumAmount: 30000,
        schemeStartedAt: new Date(2020, 7, 25),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 7,
        coverageYears: 15,
        routeTitle: "corporate-comprehensive-plan" // This field is used for routing
      },
      {
        schemeId: 6,
        schemeName: "Corporate Premium Plan",
        schemeDescription: "The Corporate Premium Plan offers the highest level of health coverage for corporate employees, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for businesses that seek to provide the ultimate health protection and peace of mind for their employees.",
        coverageAmount: 5000000,
        schemeType: "Corporate",
        basePremiumAmount: 50000,
        schemeStartedAt: new Date(2021, 10, 30),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 10,
        coverageYears: 20,
        routeTitle: "corporate-premium-plan" // This field is used for routing
      }
    ],
  
    family: [
      {
        schemeId: 7,
        schemeName: "Family Basic Plan",
        schemeDescription: "The Family Basic Plan offers essential health coverage for families, including hospitalization and emergency care benefits. This plan is designed to provide fundamental protection for your family’s health needs at an affordable premium.",
        coverageAmount: 1000000,
        schemeType: "Family",
        basePremiumAmount: 20000,
        schemeStartedAt: new Date(2018, 1, 14),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 5,
        coverageYears: 10,
        routeTitle: "family-basic-plan" // This field is used for routing
      },
      {
        schemeId: 8,
        schemeName: "Family Comprehensive Plan",
        schemeDescription: "The Family Comprehensive Plan provides extensive health coverage for families, including benefits for outpatient treatments, specialist consultations, and preventive care. This plan is ideal for families seeking a higher level of health security and comprehensive medical benefits.",
        coverageAmount: 3000000,
        schemeType: "Family",
        basePremiumAmount: 40000,
        schemeStartedAt: new Date(2019, 6, 19),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 7,
        coverageYears: 15,
        routeTitle: "family-comprehensive-plan" // This field is used for routing
      },
      {
        schemeId: 9,
        schemeName: "Family Elite Plan",
        schemeDescription: "The Family Elite Plan offers the highest level of health coverage for families, including extensive inpatient and outpatient benefits, dental care, and access to a wide network of top healthcare providers. This plan is tailored for families that seek the ultimate health protection and peace of mind.",
        coverageAmount: 6000000,
        schemeType: "Family",
        basePremiumAmount: 60000,
        schemeStartedAt: new Date(2020, 9, 25),
        schemeLastUpdatedAt: new Date(),
        paymentTerm: 10,
        coverageYears: 20,
        routeTitle: "family-elite-plan" // This field is used for routing
      }
    ]
  }
  
  