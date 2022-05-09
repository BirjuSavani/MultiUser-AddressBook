<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row">
        <div class="col-md-6">
            <h2 style="">Contact</h2>
        </div>
        <div class="col-md-6" style="text-align: right">
            <br />
            <asp:HyperLink runat="server" ID="HyperLink10" Text="ContactAdd" class="btn btn-outline-warning button1" NavigateUrl="~/AdminPanel/Contact/Add" Style="color: black"></asp:HyperLink>

        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div style="color: red">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label><br />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
            <asp:GridView runat="server" ID="gvContact" CssClass="table table-striped table-bordered table-hover table-responsive" AutoGenerateColumns="False" OnRowCommand="gvContact_RowCommand" DataKeyNames="ContactID">
                <Columns>
                   <%-- <asp:BoundField DataField="ContactID" HeaderText="ID" />--%>
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:BoundField DataField="ContactNumber" HeaderText="Number" />
                    <asp:BoundField DataField="WhatsappNumber" HeaderText="Whatsapp Number" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="ContactCategoryNames" HeaderText="Category" />
                    <%-- <asp:BoundField DataField="FilePath" HeaderText="Image" />--%>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="contactImagePath" runat="server" ImageUrl='<%# Eval("FilePath") %>' Height="70" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ??? ');" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/Contact/Edit/" + CommonDropDownFillMethods.Base64encode( Eval("ContactID").ToString().Trim()) %>' CssClass="btn btn-dark btn-sm"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>

