<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="EmployeeEditOrder.aspx.cs"
Inherits="BookFair.EmployeeEditOrder" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .custome-component-container {
      width: 100%;
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      gap: 20px;
      margin-top: 50px;
    }
    .edit-container {
      display: flex;
      flex-direction: row;
      padding: 0 30px 30px 0;
      justify-content: center;
      gap: 30px;
    }
    .btn-selsct-drop-down {
      border-radius: 0 15px 15px 0;
    }

    .edit-control {
      border-radius: 15px ;
    }

    .order-info {
      margin-bottom: 50px;
      display: flex;
      flex-direction: row;
      justify-content: space-evenly;
      align-items: center;
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

  <dx:ASPxHiddenField
    ID="ASPxHiddenFieldId"
    runat="server"
  ></dx:ASPxHiddenField>
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
  <dx:ASPxPanel
    ID="ASPxPanel2"
    runat="server"
    CssClass="order-info"
    Width="100%"
  >
    <PanelCollection>
      <dx:PanelContent>
        <dx:ASPxLabel ID="ASPxLabelCustomerName" runat="server"></dx:ASPxLabel>
        <dx:ASPxLabel ID="ASPxLabelOrderNumber" runat="server"></dx:ASPxLabel>
        <dx:ASPxLabel ID="ASPxLabelOrderStatus" runat="server"></dx:ASPxLabel>
        <dx:ASPxLabel ID="ASPxLabelOrderDate" runat="server"></dx:ASPxLabel>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>

  <dx:ASPxPanel
    ID="ASPxPanel1"
    CssClass="edit-container"
    runat="server"
    Width="100%"
  >
    <PanelCollection>
      <dx:PanelContent>
        <dx:ASPxLabel runat="server" Text="Change Order Status"></dx:ASPxLabel>

        <dx:ASPxComboBox
          ID="ASPxComboBoxOrderStatus"
          CssClass="edit-control"
          runat="server"
          ValueType="System.String"
          HorizontalAlign="Center"
        >
          <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
          <ButtonStyle CssClass="btn-selsct-drop-down"> </ButtonStyle>
        </dx:ASPxComboBox>

        <dx:ASPxButton
          ID="ASPxButton1"
          runat="server"
          CssClass="edit-control"
          Text="Save Changes"
          OnClick="ASPxButton1_Click"
        ></dx:ASPxButton>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>

  <dx:ASPxPanel
    ID="CustomeComponentContainer"
    runat="server"
    CssClass="custome-component-container"
  >
    <PanelCollection>
      <dx:PanelContent> </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>
</asp:Content>
