namespace EmailProcessingService.Helpers;

public class PaymentConfirmation
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
                .ecm-bgcolor {{ background-color: lightblue; }}
                .ecm-tablecell {{ word-break: keep-all; padding-right: 10px; vertical-align: top; }}
                .bold {{ font-weight: bold; }}
                .text-left {{ text-align: left; }}
                .text-center {{ text-align: center; }}
                .text-right {{ text-align: right; }}

                .nowrap {{ white-space: nowrap; }}
                .ecm-table td, .ecm-table th {{ padding: 1px 3px;}}
                .ecm-table-dark tr {{ background-color: #000000; color: #FFFFFF; }}
                .ecm-table-striped tr:nth-child(odd) {{ background-color: #CCCCCC; }}
                .ecm-table-striped tr:nth-child(even) {{ background-color: #EEEEEE; }}
            </mj-style>
            </mj-head>

            <mj-body>

            <mj-section css-class=""ecm-bgcolor"" full-width=""full-width"">
                <mj-column css-class=""ecm-bgcolor"">
                <mj-image width=""200px"" src=""https://angelair.ecmanage.eu/Portals/FASHIONFABRIEK/ANGELAIR/_portal_logo_1687501962551.png?ver=XdNQkxEBBrDZ8CwGlJZHcg%3d%3d""></mj-image>
                </mj-column>
            </mj-section>

            <mj-section>
                <mj-column>
                <mj-text font-size=""20px"">Bestelling geplaatst</mj-text>
                </mj-column>
            </mj-section>
            <mj-section>
                <mj-column>
                <mj-divider />
                </mj-column>
            </mj-section>

            <mj-section>
                <mj-column>
                <mj-table>
                    <tr>
                    <td class=""ecm-tablecell nowrap bold"">Ordernummer:</td>
                    <td class=""ecm-tablecell bold"">{data.Data.PaymentConfirmationData.OrderNumber}</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell nowrap bold"">Aantal punten:</td>
                    <td class=""ecm-tablecell"">80.00</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell nowrap bold"">Geplaatst op:</td>
                    <td class=""ecm-tablecell"">{data.Data.PaymentConfirmationData.PaymentDate.Value.ToString("yyyy-MM-dd")} {data.Data.PaymentConfirmationData.PaymentDate.Value.ToString("HH:mm:ss")}</td>
                    </tr>
                </mj-table>
                </mj-column>
                <mj-column>
                <mj-table>
                    <tr>
                    <td class=""ecm-tablecell bold"">Afgeleverd bij:</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell"">{data.Data.PaymentConfirmationData.CustomerName}</td>
                    </tr>
                </mj-table>
                </mj-column>
            </mj-section>
            <mj-section>
                <mj-column>
                <mj-divider />
                </mj-column>
            </mj-section>

            <mj-section>
                <mj-column>
                <mj-table>
                    <tr>
                    <td class=""ecm-tablecell bold"">Voor:</td>
                    <td class=""ecm-tablecell"">{data.Data.PaymentConfirmationData.CustomerName} (DC)<br />{data.Data.Recipient.EmailAddress}</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell bold"">Van afdeling:</td>
                    <td class=""ecm-tablecell"">Angel Air (VA)</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell bold"">Kenmerk:</td>
                    <td class=""ecm-tablecell"">test</td>
                    </tr>
                </mj-table>
                </mj-column>
                <mj-column>
                <mj-table>
                    <tr>
                    <td class=""ecm-tablecell bold"">Opmerking:</td>
                    <td class=""ecm-tablecell"">test opmerking</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell bold"">Referentie:</td>
                    <td class=""ecm-tablecell"">Ref</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell bold"">Project:</td>
                    <td class=""ecm-tablecell"">()</td>
                    </tr>
                </mj-table>
                </mj-column>
            </mj-section>
            <mj-section>
                <mj-column>
                <mj-divider />
                </mj-column>
            </mj-section>

            <mj-section>
                <mj-column>
                <mj-table width=""0px"" padding-bottom=""0px"">
                    <tr>
                    <th class=""ecm-tablecell bold text-left"">Betaalmethode</th>
                    <th class=""ecm-tablecell bold text-right"">Bedrag</th>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell text-left"">Punten</td>
                    <td class=""ecm-tablecell text-right"">80.00</td>
                    </tr>
                    <tr>
                    <td class=""ecm-tablecell text-left"">{data.Data.PaymentConfirmationData.PaymentMethod}</td>
                    <td class=""ecm-tablecell text-right"">58.00</td>
                    </tr>
                </mj-table>
                <mj-text font-size=""10px"" padding-top=""0px"">1 punt = 1 euro</mj-text>
                </mj-column>
            </mj-section>
            <mj-section>
                <mj-column>
                <mj-divider />
                </mj-column>
            </mj-section>

            <mj-section>
                <mj-column>
                <mj-text font-style=""italic"">Hieronder een overzicht van de bestelde artikelen:</mj-text>
                </mj-column>
            </mj-section>
            <mj-section>
                <mj-column>
                <mj-table css-class=""ecm-table"">
                    <thead class=""ecm-table-dark"">
                    <tr>
                        <th class=""ecm-tablecell bold text-left"">Product</th>
                        <th class=""ecm-tablecell bold text-right"">Aantal</th>
                        <th class=""ecm-tablecell bold text-right"">Subtotaal</th>
                    </tr>
                    </thead>
                    <tbody class=""ecm-table-striped"">
                    <tr>
                        <td class=""ecm-tablecell text-left"">Zomerbroek heren, blauw<br />Artikelnummer: TUG-102<br />Maat: 48<br />Punten: 80.00</td>
                        <td class=""ecm-tablecell text-right"">1</td>
                        <td class=""ecm-tablecell text-right"">80.00</td>
                    </tr>
                    <tr>
                        <td class=""ecm-tablecell text-left"">Veiligheidshelm Geel<br />Artikelnummer: 0303574<br />Maat: 53-62<br />Punten: 16.00</td>
                        <td class=""ecm-tablecell text-right"">3</td>
                        <td class=""ecm-tablecell text-right"">48.00</td>
                    </tr>
                    <tr>
                        <td class=""ecm-tablecell text-left"">Administratiekosten</td>
                        <td class=""ecm-tablecell text-right""></td>
                        <td class=""ecm-tablecell text-right"">5.00</td>
                    </tr>
                    </tbody>
                    <tfoot>
                    <tr style=""border-top: 1px solid;"">
                        <td />
                        <td class=""ecm-tablecell bold text-right"">4</td>
                        <td class=""ecm-tablecell bold text-right"">138.00</td>
                    </tr>
                    </tfoot>
                </mj-table>
                </mj-column>
            </mj-section>

            <mj-section css-class=""ecm-bgcolor"" full-width=""full-width"">
                <mj-column>
                <mj-text font-size=""10px"">Dit is een automatisch verstuurde e-mail. Hierop kan niet gereageerd worden.</mj-text>
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