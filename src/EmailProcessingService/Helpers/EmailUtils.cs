using Mjml.Net;

namespace EmailProcessingService.Helpers;

public class EmailUtils
{
  public static string CreateEmailBody(
      OracleDataEvent @event)
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
            <td class=""ecm-tablecell bold"">VA4702379</td>
          </tr>
          <tr>
            <td class=""ecm-tablecell nowrap bold"">Aantal punten:</td>
            <td class=""ecm-tablecell"">80.00</td>
          </tr>
          <tr>
            <td class=""ecm-tablecell nowrap bold"">Geplaatst op:</td>
            <td class=""ecm-tablecell"">2023-08-10 10:39:09</td>
          </tr>
        </mj-table>
      </mj-column>
      <mj-column>
        <mj-table>
          <tr>
            <td class=""ecm-tablecell bold"">Afleveradres (Anders):</td>
          </tr>
          <tr>
            <td class=""ecm-tablecell"">Dennis Coert</td>
          </tr>
          <tr>
            <td class=""ecm-tablecell"">Grutbrodk 11</td>
          </tr>
          <tr>
            <td class=""ecm-tablecell"">7008ak Drc</td>
          </tr>
          <tr>
            <td class=""ecm-tablecell"">NLD</td>
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
            <td class=""ecm-tablecell"">Dennis Coert (DC)<br />denniscoert@gmail.com</td>
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
            <td class=""ecm-tablecell text-left"">iDEAL</td>
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

    //         string text = $@"<mjml>
    //   <mj-head>
    //     <mj-style>
    //       body {{
    //         font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    //       }}
    //       table {{ 
    //         text-align: left;
    //         padding-top: 10px;
    //       }}
    //       th {{
    //         width: 200px;
    //         padding-left: 10px;
    //         background-clip: content-box;
    //         background-color: #EEEEEE;
    //         font-weight: normal;
    //       }}
    //       td {{
    //         padding: 5px;
    //         width: 300px;
    //         border: 1px solid black;
    //       }}
    //       .fine {{
    //         font-weight: bold;
    //         color: #FF0000;
    //       }}
    //       .logo {{
    //         float: left;
    //         display: block;
    //         margin-top: -15px;
    //       }}
    //       .title {{
    //         display: block;
    //       }}
    //       .logo-name {{
    //         color: #FFFFFF;
    //         background-color: #2AA3D9;
    //         vertical-align: middle;
    //         padding: 10px;
    //         margin-top: 20px;
    //         height: 20px;
    //         width: 400px;
    //       }}
    //       .logo-bar {{
    //         background-color: #005D91;
    //         width: 420px;
    //         height: 20px;
    //         margin-top: -22px;
    //         margin-bottom: 30px;
    //       }}
    //     </mj-style>
    //   </mj-head>
    //   <mj-body>
    //     <mj-section>
    //       <mj-column>
    //         <mj-image src=""https://via.placeholder.com/105x85.png"" width=""105px"" height=""85px"" alt=""Logo""></mj-image>
    //       </mj-column>
    //       <mj-column>
    //         <mj-text class=""logo-name"">Central Fine Collection Agency</mj-text>
    //         <mj-divider class=""logo-bar""></mj-divider>
    //       </mj-column>
    //     </mj-section>
    //     <mj-section>
    //       <mj-column>
    //         <mj-text>The Hague, {DateTime.Now.ToLongDateString()}</mj-text>
    //         <mj-text>Dear Mr. / Miss / Mrs. {vehicleInfo.OwnerName},</mj-text>
    //         <mj-text>We hereby inform you of the fact that a speeding violation was detected with a vehicle that is registered to you.</mj-text>
    //         <mj-text>The violation was detected by a speeding camera. We have a digital image of your vehicle committing the violation on record in our system. If requested by your solicitor, we will provide this image to you.</mj-text>
    //         <mj-divider></mj-divider>
    //         <mj-text>Below you can find all the details of the violation.</mj-text>
    //         <mj-text>
    //           <b>Vehicle information:</b>
    //           <table>
    //             <tr><th>License number</th><td>{vehicleInfo.VehicleId}</td></tr>
    //             <tr><th>Brand</th><td>{vehicleInfo.Brand}</td></tr>
    //             <tr><th>Model</th><td>{vehicleInfo.Model}</td></tr>
    //           </table>
    //         </mj-text>
    //         <mj-text>
    //           <b>Conditions during the violation:</b>
    //           <table>
    //             <tr><th>Road</th><td>{speedingViolation.RoadId}</td></tr>
    //             <tr><th>Date</th><td>{speedingViolation.Timestamp.ToString("dd-MM-yyyy")}</td></tr>
    //             <tr><th>Time of day</th><td>{speedingViolation.Timestamp.ToString("hh:mm:ss")}</td></tr>
    //           </table>
    //         </mj-text>
    //         <mj-text>
    //           <b>Sanction:</b>
    //           <table>
    //             <tr><th>Maximum speed violation</th><td>{speedingViolation.ViolationInKmh} KMh</td></tr>
    //             <tr><th>Sanction amount</th><td><div class=""fine"">{fine}</div></td></tr>
    //           </table>
    //         </mj-text>
    //         <mj-divider></mj-divider>
    //         <mj-text><b>Sanction handling:</b></mj-text>
    //         <mj-text>If the amount of the fine is to be determined by the prosecutor, you will receive a notice to appear in court shortly.</mj-text>
    //         <mj-text>Otherwise, you must pay the sanctioned fine <b>within 8 weeks</b> after the date of this email. If you fail to pay within 8 weeks, you will receive a first reminder email and <b>the fine will be increased to 1.5x the original fine amount</b>. If you fail to pay within 8 weeks after the first reminder, you will receive a second and last reminder email and <b>the fine will be increased to 3x the original fine amount</b>. If you fail to pay within 8 weeks after the second reminder, the case is turned over to the prosecutor and you will receive a notice to appear in court.</mj-text>
    //         <mj-divider></mj-divider>
    //         <mj-text>Yours sincerely,<br/>The Central Fine Collection Agency</mj-text>
    //       </mj-column>
    //     </mj-section>
    //   </mj-body>
    // </mjml>";

    var options = new MjmlOptions
    {
      Beautify = false
    };

    var (html, errors) = mjmlRenderer.Render(text, options);

    // Retourneer de HTML-body
    return html;
  }
}