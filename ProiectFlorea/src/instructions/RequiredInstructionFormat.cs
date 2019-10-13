using System;

namespace ProiectFlorea.instructions
{
    public static class RequiredInstructionFormat
    {
        private static string registerSizeRegex = "[0-9]|1[0-5]";
        private static string immediateValueRegex = @"#\d+";
        private static string offsetSizeRegex = @"\d+";

        private static string basicRegister = $"R({registerSizeRegex})";

        private static string booleanRegister = $"B({registerSizeRegex})";

        private static string floatRegister = $"F({registerSizeRegex})";

        private static string registerBooleanOrSr = $"{basicRegister}|{booleanRegister})|SR";

        private static string basicParameters =
            $"{basicRegister},{basicRegister},({basicRegister}|{immediateValueRegex})";

        private static string onlyBooleanParameters =
            $"{booleanRegister},{booleanRegister},{booleanRegister}";

        private static string onlyFloatParameters =
            $"{floatRegister},{floatRegister},{floatRegister}";

        private static string twoFloatParameters = $"{floatRegister},{floatRegister}";

        private static string booleanRegisterWithBasicParameters =
            $"{booleanRegister},{basicRegister},({basicRegister}|{immediateValueRegex})";

        private static string booleanRegisterWithFloatRegistersAsParameters =
            $"{booleanRegister},{floatRegister},{floatRegister}";

        private static string basicRegisterGroup = $"\\({basicRegister},{basicRegister})\\)";

        private static string offsetOrRegisterGroup =
            $"({offsetSizeRegex}\\({basicRegister})\\)|{basicRegisterGroup})";


        // SPECIAL INSTRUCTION

        // TODO: ADD MOV PC,Ri #delay-count
        public static string MOV => $"^MOV ({basicRegister},{booleanRegister}|{basicRegister},SR|{booleanRegister},{basicRegister}|SR,{basicRegister}|SR,{immediateValueRegex}|{basicRegister},{floatRegister})";
        public static string AND => $"^AND ({basicParameters}|{onlyBooleanParameters})$";
        public static string OR => $"^OR ({basicParameters}|{onlyBooleanParameters})$";

        // ARITHMETIC UNIT INSTRUCTIONS
        public static string ADD => $"^ADD {basicParameters}$";
        public static string ADDV => $"^ADDV {basicParameters}$";
        public static string SUB => $"^SUB {basicParameters}$";
        public static string SUBV => $"^SUBV {basicParameters}$";
        public static string ADDC => $"^ADDC {basicParameters}$";
        public static string SUBC => $"^SUBC {basicParameters}$";
        public static string DIV => $"^DIV {basicParameters}$";
        public static string DIVV => $"^DIVV {basicParameters}$";
        public static string MOD => $"^MOD {basicParameters}$";

        // SHIFT UNIT INSTRUCTIONS

        public static string ASL => $"^ASL {basicParameters}$";
        public static string ASLV => $"^ASLV {basicParameters}$";
        public static string ASR => $"^ASR {basicParameters}$";
        public static string EOR => $"^EOR {basicParameters}$";
        public static string EXT => $"^EXT R({registerSizeRegex}),R({registerSizeRegex})$";
        public static string BIC => $"^BIC {basicParameters}$";

        // MULTIPLY UNIT INSTRUCTIONS

        public static string MULT => $"^MULT {basicParameters}$";
        public static string MULTV => $"^MULTV {basicParameters}$";

        // RELATIONAL UNIT INSTRUCTIONS

        public static string GTS => $"^GTS {booleanRegisterWithBasicParameters}$";
        public static string GES => $"^GES {booleanRegisterWithBasicParameters}$";
        public static string LTS => $"^LTS {booleanRegisterWithBasicParameters}$";
        public static string LES => $"^LES {booleanRegisterWithBasicParameters}$";
        public static string GTU => $"^GTU {booleanRegisterWithBasicParameters}$";
        public static string GEU => $"^GEU {booleanRegisterWithBasicParameters}$";
        public static string LTU => $"^LTU {booleanRegisterWithBasicParameters}$";
        public static string LEU => $"^LEU {booleanRegisterWithBasicParameters}$";
        public static string EQ => $"^EQ ({booleanRegisterWithBasicParameters}|{onlyBooleanParameters})$";
        public static string NE => $"^NE ({booleanRegisterWithBasicParameters}|{onlyBooleanParameters})$";
        public static string GT => $"^GT {onlyBooleanParameters}$";
        public static string GE => $"^GE {onlyBooleanParameters}$";
        public static string LT => $"^LT {onlyBooleanParameters}$";
        public static string LE => $"^LE {onlyBooleanParameters}$";

        // MEMORY REFERENCE

        public static string LD => $"^LD ({registerBooleanOrSr}),{offsetOrRegisterGroup}$";
        public static string LDB => $"^LDB {basicRegister},{offsetOrRegisterGroup}$";
        public static string LDD => $"^LDD {basicRegister},{offsetOrRegisterGroup}$";
        public static string LDQ => $"^LDQ {basicRegister},{offsetOrRegisterGroup}$";
        public static string ST => $"^ST {offsetOrRegisterGroup},({registerBooleanOrSr})$";
        public static string STB => $"^STB {offsetOrRegisterGroup},{basicRegister}$";
        public static string STD => $"^STD {offsetOrRegisterGroup},{basicRegister}$";
        public static string STQ => $"^STQ {offsetOrRegisterGroup},{basicRegister}$";

        // BRANCH INSTRUCTIONS
        // TODO: ADD BRANCH INSTRUCTIONS , ASK FLOREA WHAT #delay-count means, and #n

        // SPECIAL PURPOSE INSTRUCTIONS

        public static string EI => "^EI$";
        public static string DI => "^DI$";

        // FLOATING-POINT RELATIONAL UNIT

        public static string GTSSF => $"^GTSSF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string GTSDF => $"^GTSDF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string GESSF => $"^GESSF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string GESDF => $"^GESDF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string LTSSF => $"^LTSSF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string LTSDF => $"^LTSDF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string LESSF => $"^LESSF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string LESDF => $"^LESDF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string EQSF => $"^EQSF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string EQDF => $"^EQDF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string NESF => $"^NESF {booleanRegisterWithFloatRegistersAsParameters}$";
        public static string NEDF => $"^NEDF {booleanRegisterWithFloatRegistersAsParameters}$";

        // FLOATING-POINT ADD UNIT

        public static string ADDSF => $"^ADDSF {onlyFloatParameters}$";
        public static string ADDDF => $"^ADDDF {onlyFloatParameters}$";
        public static string SUBSF => $"^SUBSF {onlyFloatParameters}$";
        public static string SUBDF => $"^SUBDF {onlyFloatParameters}$";
        public static string NEGSF => $"^NEGSF {twoFloatParameters}$";
        public static string NEGDF => $"^NEGDF {twoFloatParameters}$";
        public static string DIVSF => $"^DIVSF {onlyFloatParameters}$";
        public static string DIVDF => $"^DIVDF {onlyFloatParameters}$";
        public static string MODSF => $"^MODSF {onlyFloatParameters}$";
        public static string MODDF => $"^MODDF {onlyFloatParameters}$";
        public static string MOVSF => $"^MOVSF {floatRegister},({floatRegister}|{basicRegister})$";
        public static string MOVDF => $"^MOVDF {twoFloatParameters}$";
        public static string EXTDF => $"^EXTDF {twoFloatParameters}$";
        public static string TRUNCSF => $"^TRUNCSF {twoFloatParameters}$";

        // FLOATING-POINT MULTIPLY UNIT

        public static string MULTSF => $"^MULTSF {onlyFloatParameters}$";
        public static string MULTDF => $"^MULTDF {onlyFloatParameters}$";

        // FLOATING-POINT MEMORY REFERENCE

        public static string LDSF => $"^LDSF {floatRegister},{offsetOrRegisterGroup}$";
        public static string LDDF => $"^LDDF {floatRegister},{offsetOrRegisterGroup}$";
        public static string LDQF => $"^LDQF {floatRegister},{offsetOrRegisterGroup}$";
        public static string STSF => $"^STSF {offsetOrRegisterGroup},{floatRegister}$";
        public static string STDF => $"^STDF {offsetOrRegisterGroup},{floatRegister}$";
        public static string STQF => $"^STQF {offsetOrRegisterGroup},{floatRegister}$";
    }
}