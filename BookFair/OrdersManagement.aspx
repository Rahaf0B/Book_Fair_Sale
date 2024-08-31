<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="OrdersManagement.aspx.cs"
Inherits="BookFair.OrdersManagement" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .panel-footer-pager-container {
      width: 300px;
      display: flex;
      flex-direction: row;
      align-items: center;
      margin: auto;
      margin-top: 20px;
      justify-content: space-evenly;
    }

    .container-btn-pager {
      display: flex;
      flex-direction: row;
      align-items: center;
      justify-content: center;
    }

    .pager-btn {
      background-color: transparent;
      border: none;
      width: 30px;
    }
    .element-panel-container {
      margin: auto;
      width: fit-content;
      margin-top: 20px;
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
  </style>

     <div class="page-redirect-container">
   <dx:ASPxButton
     ID="ASPxButtonBack"
     UseSubmitBehavior="false"
     CssClass="btn-option-page-redirect"
     runat="server"
     OnClick="Goback_ButtonClick"
     Image-Url="~/utlis/Images/iconBack.svg"
     Image-Width="50px"
   >
     <Image Width="50px" Url="~/utlis/Images/iconBack.svg"></Image>
   </dx:ASPxButton>
   <dx:aspxlabel
     ID="labelPageRedirect"
     CssClass="label-page-redirect"
     Text="Go Back To Orders Page"
     runat="server"
   ></dx:aspxlabel>
 </div>
  <dx:ASPxPanel runat="server" ID="ElementPagerContainer" Width="100%">
    <PanelCollection>
      <dx:PanelContent>
        <dx:aspxpanel
          ID="ElementPanelContainer"
          CssClass="element-panel-container"
          runat="server"
          ViewStateMode="Enabled"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:ASPxGridView
                ID="ASPxGridViewOrderData"
                runat="server"
                AutoGenerateColumns="False"
                OnRowCommand="GridView1_RowCommand"
                KeyFieldName="id"
              >
                <SettingsPager Visible="False"> </SettingsPager>
                <SettingsPopup>
                  <FilterControl AutoUpdatePosition="False"></FilterControl>
                </SettingsPopup>

                <Columns>
                  <dx:GridViewDataTextColumn
                    Caption="Customter Name"
                    FieldName="customer_name"
                    ShowInCustomizationForm="True"
                    VisibleIndex="2"
                  >
                    <EditFormSettings Visible="False" />
                    <HeaderStyle
                      HorizontalAlign="Center"
                      VerticalAlign="Middle"
                    />
                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                    </CellStyle>
                  </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn
                    Caption="Order Number"
                    FieldName="id"
                    ShowInCustomizationForm="True"
                    VisibleIndex="1"
                  >
                    <EditFormSettings Visible="False" />
                    <HeaderStyle
                      HorizontalAlign="Center"
                      VerticalAlign="Middle"
                    />
                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                    </CellStyle>
                  </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn
                    Caption="Date"
                    FieldName="date"
                    ShowInCustomizationForm="True"
                    VisibleIndex="5"
                  >
                    <EditFormSettings Visible="False" />
                    <HeaderStyle
                      HorizontalAlign="Center"
                      VerticalAlign="Middle"
                    />
                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                    </CellStyle>
                  </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn
                    Caption="Total Price"
                    FieldName="total_price"
                    ShowInCustomizationForm="True"
                    VisibleIndex="5"
                  >
                    <EditFormSettings Visible="False" />
                    <HeaderStyle
                     HorizontalAlign="Center"
                     VerticalAlign="Middle"
                    />
                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                    </CellStyle>
                  </dx:GridViewDataTextColumn>
                  <dx:GridViewDataComboBoxColumn
                    Caption="Status"
                    FieldName="status"
                    ShowInCustomizationForm="True"
                    UnboundType="Object"
                    VisibleIndex="4"
                  >
                    <PropertiesComboBox DropDownStyle="DropDown">
                    </PropertiesComboBox>
                    <HeaderStyle
                      HorizontalAlign="Center"
                      VerticalAlign="Middle"
                    />
                    <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                    </CellStyle>
                  </dx:GridViewDataComboBoxColumn>

                  <dx:gridviewdatacolumn VisibleIndex="10" Width="15%">
                    <dataitemtemplate>
                      <dx:aspxbutton
                        ID="ASPxButton1"
                        CssClass="btn-view-details"
                        runat="server"
                        Text="View Details"
                        CommandName="Details"
                        CommandArgument="<%# Container.ItemIndex %>"
                      ></dx:aspxbutton>
                    </dataitemtemplate>
                  </dx:gridviewdatacolumn>
                </Columns>
                <Styles>
                  <HeaderFilterItem
                    HorizontalAlign="Center"
                    VerticalAlign="Middle"
                  >
                  </HeaderFilterItem>
                </Styles>
              </dx:ASPxGridView>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>

        <dx:aspxpanel
          ID="FooterPagerContainer"
          CssClass="panel-footer-pager-container"
          runat="server"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:aspxlabel ID="labelPageFooter" runat="server"></dx:aspxlabel>
              <div class="container-btn-pager">
                <dx:aspxbutton
                  ID="btnPagerPrev"
                  CssClass="pager-btn"
                  runat="server"
                  Image-Url="~/utlis/Images/iconPrev.svg"
                  Image-Width="30px"
                  OnClick="btnPagerPrev_Click"
                  AutoPostBack="False"
                >
                  <image Width="30px" Url="~/utlis/Images/iconPrev.svg"></image>
                </dx:aspxbutton>
                <dx:aspxlabel
                  ID="labelPagerNumber"
                  runat="server"
                ></dx:aspxlabel>

                <dx:aspxbutton
                  ID="btnPagerNext"
                  AutoPostBack="false"
                  CssClass="pager-btn"
                  runat="server"
                  Image-Url="~/utlis/Images/iconNext.svg"
                  Image-Width="30px"
                  OnClick="btnPagerNext_Click"
                >
                  <image Width="30px" Url="~/utlis/Images/iconNext.svg"></image>
                </dx:aspxbutton>
              </div>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>
</asp:Content>
