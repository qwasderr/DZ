<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template match="GameStore">

<HTML>

<BODY>

<p>

<H2>Ігровий магазин</H2> </p>

</BODY>

<BODY>

<TABLE BORDER="2">

<TR>
<TD>

<b>Номер</b>

</TD>

<TD>

<b>Назва</b>

</TD>

<TD>

<b>Рік випуску</b>

</TD>

<TD>

<b>Розмір(Гб)</b>

</TD>

<TD>

<b>Дизайнери</b>

</TD>
<TD>

<b>Кодери</b>

</TD>
<TD>

<b>Тестувальники</b>

</TD>

</TR>

<xsl:apply-templates select="Game"/>

</TABLE>

</BODY>

</HTML>

</xsl:template>

<xsl:template match="Game">

<TR>

<TD>


<xsl:value-of select="@ID"/>


</TD>

<TD><xsl:value-of select="@NAME_G"/></TD>

<TD><xsl:value-of select="@YEAR"/></TD>
	
	<TD>
		<xsl:value-of select="@SIZE_GB"/>
	</TD>



<xsl:for-each select="Crew">
	<xsl:if test="@NAME_C='Designers'">
		<TD>
			<xsl:for-each select="Dev">
				<p>
					<xsl:value-of select="@NAME_D"/>
	
					 (<xsl:value-of select="@AGE"/> y.o.)
				</p>




			</xsl:for-each>
		</TD>
	</xsl:if>
	<xsl:if test="@NAME_C='Programmers'">
		<TD>
			<xsl:for-each select="Dev">
				<p>
					<xsl:value-of select="@NAME_D"/>
					(<xsl:value-of select="@AGE"/> y.o.)
				</p>




			</xsl:for-each>
		</TD>
	</xsl:if>
	<xsl:if test="@NAME_C='Testers'">
		<TD>
			<xsl:for-each select="Dev">
				<p>
					<xsl:value-of select="@NAME_D"/>
					(<xsl:value-of select="@AGE"/> y.o.)
				</p>




			</xsl:for-each>
		</TD>
	</xsl:if>
</xsl:for-each>



</TR>

</xsl:template>

</xsl:stylesheet>