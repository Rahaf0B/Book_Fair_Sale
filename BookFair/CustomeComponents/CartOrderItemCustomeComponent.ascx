<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartOrderItemCustomeComponent.ascx.cs" Inherits="BookFair.CustomeComponents.CartOrderItemCustomeComponent" %>
<style>
    .image-container{
    width:100px;
    height:50px
    }
    .info-cart-order-element-container{
    width:100%;
    flex-direction: column;

    height: 100%;
    display: flex;

    justify-content: space-between;
    align-items: stretch;
    }

    .image-sub-info-container{
    display:flex;
    flex-direction:row;
    align-items: center;
    gap:20px;
    }
    .sub-info-container{
    display:flex;
    flex-direction:row;
    justify-content: space-around;
    align-items: center;
    }

    .cart-order-item-container{
    display:flex;
    flex-direction:row;
    align-items: flex-end;
    height:100%;
    }

    .image-item{
    width:100%;
    object-fit:contain;
    }

    .custome-cart-order-element-container{
    box-shadow: 1px 1px 15px 2px rgba(230,189,150,0.60);

    border-radius:15px;
    padding:20px;
    width:600px;
    }


    .btn-option-cart-order{
    border-radius:15px;


    }

    .item-quantity-options-container{
    display:flex;
    flex-direction:row;
    align-items: center;
    justify-content: center;
    }

    .item-options-container{
    width:250px;
    display:flex;
    flex-direction:column;
    align-items: center;

    gap: 25px;
    }

    .quantity-text{
    width:50px;
    height:40px;
    border-radius:15px;
    text-align: center;
    color: black;
    }

    .btn-quantity-change{
    background-color:transparent;
    }
</style>

<dx:ASPxPanel ID="ASPxPanelElementCartOrderContainerCustome"
    CssClass="custome-cart-order-element-container" runat="server" Height="200px">

    <PanelCollection>
        <dx:PanelContent>
            <dx:ASPxHiddenField ID="ASPxHiddenFieldId" runat="server"></dx:ASPxHiddenField>
            <div class="cart-order-item-container">


                <div class="info-cart-order-element-container">
                    <div class="image-sub-info-container">

                        <div class="image-container">

                            <dx:ASPxImage ID="ASPxElementImage" CssClass="image-item" runat="server"
                                ShowLoadingImage="true" ImageUrl=""></dx:ASPxImage>

                        </div>

                        <dx:ASPxLabel ID="ASPxElementLabelTitle" runat="server" Text=""></dx:ASPxLabel>
                    </div>

                    <dx:ASPxLabel ID="ASPxElementLabelPrice" runat="server" Text=""></dx:ASPxLabel>

                </div>

                <dx:ASPxPanel runat="server" ID="ItemOptionsContainer"
                    CssClass="item-options-container">
                    <PanelCollection>
                        <dx:PanelContent>


                            <dx:ASPxPanel runat="server" ID="QuantityOptionContainer"
                                CssClass="item-quantity-options-container">
                                <PanelCollection>
                                    <dx:PanelContent>


                                        <dx:ASPxButton ID="ASPxButtonAdd"
                                            CssClass="btn-option-cart-order btn-quantity-change"
                                            runat="server" OnClick="CustomControlAdd_ButtonClick"
                                            Image-Url="~/utlis/Images/iconPlus.svg"
                                            Image-Width="30px" UseSubmitBehavior="False"></dx:ASPxButton>
                                        <dx:ASPxTextBox Enabled="false" ID="ASPxTextBoxItemNumber"
                                            runat="server" CssClass="quantity-text"
                                            HorizontalAlign="Center" ForeColor="Black"></dx:ASPxTextBox>

                                        <dx:ASPxButton ID="ASPxButtonDecrease"
                                            CssClass="btn-option-cart-order btn-quantity-change"
                                            runat="server"
                                            OnClick="CustomControlDecrease_ButtonClick"
                                            Image-Url="~/utlis/Images/iconMinus.svg"
                                            Image-Width="30px" UseSubmitBehavior="False"></dx:ASPxButton>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxPanel>
                            <dx:ASPxButton ID="ASPxButtonRemove" runat="server" Width="120px"
                                Height="35px" CssClass="btn-option-cart-order btn-remove"
                                Text="Remove" UseSubmitBehavior="false"
                                OnClick="CustomControlRemove_ButtonClick">


                            </dx:ASPxButton>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </div>
        </dx:PanelContent>
    </PanelCollection>

</dx:ASPxPanel>