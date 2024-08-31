<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="OrdersPage.aspx.cs"
Inherits="BookFair.OrdersPage" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .elemnt-table-container {
      padding: 20px;
    }

    .items-contaner {
      margin: auto;
      box-shadow: 1px 1px 15px 2px rgba(230, 189, 150, 0.6);
    }

    .page-redirect-container {
      width: 260px;
      display: flex;
      flex-direction: row;
      align-items: center;
      margin-bottom: 30px;
      padding: 20px;
    }
    .btn-option-page-redirect {
      background-color: transparent;
    }

    .label-page-redirect {
      font-size: 15px;
    }
    .btn-details {
      border-radius: 15px;
    }
  </style>

  <dx:ASPxPanel
    ID="ASPxPanel1"
    runat="server"
    Width="100%"
    CssClass="elemnt-table-container"
  >
    <PanelCollection>
      <dx:PanelContent>
        <div class="page-redirect-container">
          <dx:ASPxButton
            ID="ASPxButtonBack"
            CssClass="btn-option-page-redirect"
            runat="server"
            UseSubmitBehavior="false"
            OnClick="Goback_ButtonClick"
            Image-Url="~/utlis/Images/iconBack.svg"
            Image-Width="50px"
          >
            <Image Width="50px" Url="~/utlis/Images/iconBack.svg"></Image>
          </dx:ASPxButton>
          <dx:aspxlabel
            ID="labelPageRedirect"
            CssClass="label-page-redirect"
            Text="Go Back To Home Page"
            runat="server"
          ></dx:aspxlabel>
        </div>

        <dx:ASPxGridView
          ID="ASPxGridViewOrderInfo"
          runat="server"
          AutoGenerateColumns="False"
          CssClass="items-contaner"
          OnRowCommand="GridView1_RowCommand"
          Border-BorderStyle="None"
          KeyFieldName="id"
        >
          <stylescontextmenu>
            <common>
              <item HorizontalAlign="Center"> </item>
            </common>
            <column>
              <style HorizontalAlign="Center" VerticalAlign="Middle"></style>
              <item HorizontalAlign="Center"> </item>
            </column>
          </stylescontextmenu>
          <SettingsPager Mode="ShowAllRecords"> </SettingsPager>
          <SettingsPopup>
            <FilterControl AutoUpdatePosition="False"> </FilterControl>
          </SettingsPopup>
          <Columns>
            <dx:GridViewDataTextColumn
              Caption="Order Number"
              FieldName="id"
              Name="OrderNumber"
              ShowInCustomizationForm="True"
              VisibleIndex="0"
            >
              <headerstyle HorizontalAlign="Center" />
              <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn
              Caption="Status"
              FieldName="status"
              Name="Status"
              ShowInCustomizationForm="True"
              VisibleIndex="1"
            >
              <headerstyle HorizontalAlign="Center" />
              <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn
              Caption="Date"
              FieldName="date"
              Name="Date"
              ShowInCustomizationForm="True"
              VisibleIndex="2"
            >
              <headerstyle HorizontalAlign="Center" />
              <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn
                Caption="Total Price"
                FieldName="total_price"
                Name="Total_Price"
                ShowInCustomizationForm="True"
                VisibleIndex="2"
            >
                <headerstyle HorizontalAlign="Center" />
                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </dx:GridViewDataTextColumn>

            <dx:gridviewdatacolumn VisibleIndex="10" Width="15%">
              <dataitemtemplate>
                <dx:aspxbutton
                  ID="ASPxButton1"
                  CssClass="btn-details"
                  runat="server"
                  Text="View Details"
                  CommandName="Details"
                  CommandArgument="<%# Container.ItemIndex %>"
                ></dx:aspxbutton>
              </dataitemtemplate>
            </dx:gridviewdatacolumn>
          </Columns>

          <Border BorderStyle="None"></Border>
        </dx:ASPxGridView>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>
</asp:Content>
