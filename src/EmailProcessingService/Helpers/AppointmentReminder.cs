namespace EmailProcessingService.Helpers;

public class AppointmentReminder
{
    public static string CreateEmailBody(
      OracleDataEvent data)
    {
        var mjmlRenderer = new MjmlRenderer();

        string text = $@"
        <mjml>
            <mj-head>
                <mj-attributes>
                <mj-all font-family=""Verdana"" />
                <mj-section padding=""0px"" />
                <mj-divider border-width=""2px"" border-style=""solid"" border-color=""#eee"" />
                </mj-attributes>

                <mj-style>
                .ecm-bgcolor {{ background-color: lightblue; }} .ecm-tablecell {{ word-break:
                keep-all; padding-right: 10px; vertical-align: top; }} .bold {{ font-weight:
                bold; }} .text-left {{ text-align: left; }} .text-center {{ text-align:
                center; }} .text-right {{ text-align: right; }} .nowrap {{ white-space:
                nowrap; }} .ecm-table td, .ecm-table th {{ padding: 1px 3px;}}
                .ecm-table-dark tr {{ background-color: #000000; color: #FFFFFF; }}
                .ecm-table-striped tr:nth-child(odd) {{ background-color: #CCCCCC; }}
                .ecm-table-striped tr:nth-child(even) {{ background-color: #EEEEEE; }}
                </mj-style>
            </mj-head>

            <mj-body>
                <mj-section css-class=""ecm-bgcolor"" full-width=""full-width"">
                <mj-column css-class=""ecm-bgcolor"">
                    <mj-image
                    width=""200px""
                    src=""https://angelair.ecmanage.eu/Portals/FASHIONFABRIEK/ANGELAIR/_portal_logo_1687501962551.png?ver=XdNQkxEBBrDZ8CwGlJZHcg%3d%3d""
                    ></mj-image>
                </mj-column>
                </mj-section>

                <mj-section>
                <mj-column>
                    <mj-text font-size=""20px"">Afspraakherinnering</mj-text>
                </mj-column>
                </mj-section>
                <mj-section>
                <mj-column>
                    <mj-divider />
                </mj-column>
                </mj-section>

                <!-- Hier voeg je de inhoud van de afspraakherinnering in -->
                <!-- Bijvoorbeeld: datum, tijd, locatie, etc. -->

                <mj-section>
                <mj-column>
                    <mj-text font-style=""italic""
                    >Vriendelijk herinneren wij u aan uw afspraak op {data.Data.AppointmentReminderData.AppointmentDateTime.Value.ToString("yyyy-MM-dd")} om {data.Data.AppointmentReminderData.AppointmentDateTime.Value.ToString("HH:mm:ss")} in
                    {data.Data.AppointmentReminderData.Location}.</mj-text
                    >
                </mj-column>
                </mj-section>

                <!-- Einde van de inhoud van de afspraakherinnering -->

                <mj-section css-class=""ecm-bgcolor"" full-width=""full-width"">
                <mj-column>
                    <mj-text font-size=""10px""
                    >Dit is een automatisch verstuurde e-mail. Hierop kan niet gereageerd
                    worden.</mj-text
                    >
                </mj-column>
                </mj-section>
            </mj-body>
        </mjml>";

        var options = new MjmlOptions
        {
            Beautify = false
        };

        var (html, errors) = mjmlRenderer.Render(text, options);

        // Retourneer de HTML-body
        return html;
    }
}