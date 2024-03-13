namespace EmailProcessingService.Helpers;

public class Newsletter
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
                    <mj-text font-size=""20px"">Nieuwsbrief</mj-text>
                </mj-column>
                </mj-section>
                <mj-section>
                <mj-column>
                    <mj-divider />
                </mj-column>
                </mj-section>

                <!-- Inhoud van de nieuwsbrief -->

                <mj-section>
                <mj-column>
                    <mj-text font-style=""italic""
                    >Hieronder vindt u de laatste updates en nieuws:</mj-text
                    >
                </mj-column>
                </mj-section>

                <!-- Voeg hier de inhoud van de nieuwsbrief toe -->

                <mj-section css-class=""ecm-bgcolor"" full-width=""full-width"">
                <mj-column>
                    <mj-text font-size=""10px""
                    >{data.Data.NewsletterData.Content}</mj-text
                    >
                </mj-column>
                </mj-section>

                <mj-section css-class=""ecm-bgcolor"" full-width=""full-width"">
                <mj-column css-class=""ecm-bgcolor"">
                    <mj-image
                    width=""200px""
                    src=""{data.Data.NewsletterData.Image}""
                    ></mj-image>
                </mj-column>
                </mj-section>

                <mj-section>
                <mj-column>
                    <mj-text font-style=""italic""
                    >{data.Data.NewsletterData.Link}</mj-text
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