PGDMP                      }           ecoffee    17.3    17.3 C    
           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false                       1262    24936    ecoffee    DATABASE     m   CREATE DATABASE ecoffee WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en-GB';
    DROP DATABASE ecoffee;
                     postgres    false            �            1259    24937    accessories    TABLE     �   CREATE TABLE public.accessories (
    brand text,
    image text,
    name text,
    price numeric,
    slug text,
    "ID" integer NOT NULL
);
    DROP TABLE public.accessories;
       public         heap r       postgres    false            �            1259    24942    accessories_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."accessories_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public."accessories_ID_seq";
       public               postgres    false    217                       0    0    accessories_ID_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."accessories_ID_seq" OWNED BY public.accessories."ID";
          public               postgres    false    218            �            1259    24943 	   beverages    TABLE     �   CREATE TABLE public.beverages (
    brand text,
    image text,
    name text,
    price numeric,
    slug text,
    "ID" integer NOT NULL
);
    DROP TABLE public.beverages;
       public         heap r       postgres    false            �            1259    24948    beverages_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."beverages_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public."beverages_ID_seq";
       public               postgres    false    219                       0    0    beverages_ID_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."beverages_ID_seq" OWNED BY public.beverages."ID";
          public               postgres    false    220            �            1259    24949    capsules    TABLE     �   CREATE TABLE public.capsules (
    brand text,
    image text,
    name text,
    price numeric,
    slug text,
    "ID" integer NOT NULL
);
    DROP TABLE public.capsules;
       public         heap r       postgres    false            �            1259    24954    capsules_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."capsules_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."capsules_ID_seq";
       public               postgres    false    221                       0    0    capsules_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."capsules_ID_seq" OWNED BY public.capsules."ID";
          public               postgres    false    222            �            1259    24955    cart    TABLE     n   CREATE TABLE public.cart (
    id integer NOT NULL,
    uid integer,
    pid integer,
    quantity integer
);
    DROP TABLE public.cart;
       public         heap r       postgres    false            �            1259    24958    cart_id_seq    SEQUENCE     �   CREATE SEQUENCE public.cart_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.cart_id_seq;
       public               postgres    false    223                       0    0    cart_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE public.cart_id_seq OWNED BY public.cart.id;
          public               postgres    false    224            �            1259    24959    customer_products    TABLE     ^   CREATE TABLE public.customer_products (
    cid integer NOT NULL,
    pid integer NOT NULL
);
 %   DROP TABLE public.customer_products;
       public         heap r       postgres    false            �            1259    24962    machines    TABLE     �   CREATE TABLE public.machines (
    brand text,
    image text,
    name text,
    price numeric,
    slug text,
    "ID" integer NOT NULL
);
    DROP TABLE public.machines;
       public         heap r       postgres    false            �            1259    24967    machines_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."machines_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."machines_ID_seq";
       public               postgres    false    226                       0    0    machines_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."machines_ID_seq" OWNED BY public.machines."ID";
          public               postgres    false    227            �            1259    24968    products    TABLE     �   CREATE TABLE public.products (
    brand text NOT NULL,
    image text NOT NULL,
    name text NOT NULL,
    price numeric(10,2) NOT NULL,
    slug text NOT NULL,
    category text NOT NULL,
    id integer NOT NULL,
    stock integer
);
    DROP TABLE public.products;
       public         heap r       postgres    false            �            1259    24973    products_id_seq    SEQUENCE     �   CREATE SEQUENCE public.products_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.products_id_seq;
       public               postgres    false    228                       0    0    products_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.products_id_seq OWNED BY public.products.id;
          public               postgres    false    229            �            1259    24974    users    TABLE     �   CREATE TABLE public.users (
    address text,
    email text,
    name text,
    phone text,
    surname text,
    "ID" integer NOT NULL,
    password text,
    role text
);
    DROP TABLE public.users;
       public         heap r       postgres    false            �            1259    24979    users_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."users_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public."users_ID_seq";
       public               postgres    false    230                       0    0    users_ID_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public."users_ID_seq" OWNED BY public.users."ID";
          public               postgres    false    231            �            1259    24980    variety    TABLE     �   CREATE TABLE public.variety (
    brand text,
    image text,
    name text,
    price numeric,
    slug text,
    "ID" integer NOT NULL
);
    DROP TABLE public.variety;
       public         heap r       postgres    false            �            1259    24985    variety_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."variety_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."variety_ID_seq";
       public               postgres    false    232                       0    0    variety_ID_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public."variety_ID_seq" OWNED BY public.variety."ID";
          public               postgres    false    233            H           2604    24986    accessories ID    DEFAULT     t   ALTER TABLE ONLY public.accessories ALTER COLUMN "ID" SET DEFAULT nextval('public."accessories_ID_seq"'::regclass);
 ?   ALTER TABLE public.accessories ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    218    217            I           2604    24987    beverages ID    DEFAULT     p   ALTER TABLE ONLY public.beverages ALTER COLUMN "ID" SET DEFAULT nextval('public."beverages_ID_seq"'::regclass);
 =   ALTER TABLE public.beverages ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    220    219            J           2604    24988    capsules ID    DEFAULT     n   ALTER TABLE ONLY public.capsules ALTER COLUMN "ID" SET DEFAULT nextval('public."capsules_ID_seq"'::regclass);
 <   ALTER TABLE public.capsules ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    222    221            K           2604    24989    cart id    DEFAULT     b   ALTER TABLE ONLY public.cart ALTER COLUMN id SET DEFAULT nextval('public.cart_id_seq'::regclass);
 6   ALTER TABLE public.cart ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    224    223            L           2604    24990    machines ID    DEFAULT     n   ALTER TABLE ONLY public.machines ALTER COLUMN "ID" SET DEFAULT nextval('public."machines_ID_seq"'::regclass);
 <   ALTER TABLE public.machines ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    227    226            M           2604    24991    products id    DEFAULT     j   ALTER TABLE ONLY public.products ALTER COLUMN id SET DEFAULT nextval('public.products_id_seq'::regclass);
 :   ALTER TABLE public.products ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    229    228            N           2604    24992    users ID    DEFAULT     h   ALTER TABLE ONLY public.users ALTER COLUMN "ID" SET DEFAULT nextval('public."users_ID_seq"'::regclass);
 9   ALTER TABLE public.users ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    231    230            O           2604    24993 
   variety ID    DEFAULT     l   ALTER TABLE ONLY public.variety ALTER COLUMN "ID" SET DEFAULT nextval('public."variety_ID_seq"'::regclass);
 ;   ALTER TABLE public.variety ALTER COLUMN "ID" DROP DEFAULT;
       public               postgres    false    233    232            �          0    24937    accessories 
   TABLE DATA           L   COPY public.accessories (brand, image, name, price, slug, "ID") FROM stdin;
    public               postgres    false    217    I       �          0    24943 	   beverages 
   TABLE DATA           J   COPY public.beverages (brand, image, name, price, slug, "ID") FROM stdin;
    public               postgres    false    219   K       �          0    24949    capsules 
   TABLE DATA           I   COPY public.capsules (brand, image, name, price, slug, "ID") FROM stdin;
    public               postgres    false    221   �L       �          0    24955    cart 
   TABLE DATA           6   COPY public.cart (id, uid, pid, quantity) FROM stdin;
    public               postgres    false    223   �N       �          0    24959    customer_products 
   TABLE DATA           5   COPY public.customer_products (cid, pid) FROM stdin;
    public               postgres    false    225   �N                  0    24962    machines 
   TABLE DATA           I   COPY public.machines (brand, image, name, price, slug, "ID") FROM stdin;
    public               postgres    false    226   �N                 0    24968    products 
   TABLE DATA           X   COPY public.products (brand, image, name, price, slug, category, id, stock) FROM stdin;
    public               postgres    false    228   �P                 0    24974    users 
   TABLE DATA           [   COPY public.users (address, email, name, phone, surname, "ID", password, role) FROM stdin;
    public               postgres    false    230   ��                 0    24980    variety 
   TABLE DATA           H   COPY public.variety (brand, image, name, price, slug, "ID") FROM stdin;
    public               postgres    false    232   ֋                  0    0    accessories_ID_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."accessories_ID_seq"', 9, true);
          public               postgres    false    218                       0    0    beverages_ID_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."beverages_ID_seq"', 10, true);
          public               postgres    false    220                       0    0    capsules_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."capsules_ID_seq"', 8, true);
          public               postgres    false    222                       0    0    cart_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.cart_id_seq', 58, true);
          public               postgres    false    224                       0    0    machines_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."machines_ID_seq"', 4, true);
          public               postgres    false    227                       0    0    products_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.products_id_seq', 21, true);
          public               postgres    false    229                       0    0    users_ID_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."users_ID_seq"', 80, true);
          public               postgres    false    231                       0    0    variety_ID_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."variety_ID_seq"', 5, true);
          public               postgres    false    233            Q           2606    24998    accessories accessories_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.accessories
    ADD CONSTRAINT accessories_pkey PRIMARY KEY ("ID");
 F   ALTER TABLE ONLY public.accessories DROP CONSTRAINT accessories_pkey;
       public                 postgres    false    217            S           2606    25000    beverages beverages_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.beverages
    ADD CONSTRAINT beverages_pkey PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public.beverages DROP CONSTRAINT beverages_pkey;
       public                 postgres    false    219            U           2606    25002    capsules capsules_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.capsules
    ADD CONSTRAINT capsules_pkey PRIMARY KEY ("ID");
 @   ALTER TABLE ONLY public.capsules DROP CONSTRAINT capsules_pkey;
       public                 postgres    false    221            W           2606    25004    cart cart_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.cart
    ADD CONSTRAINT cart_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.cart DROP CONSTRAINT cart_pkey;
       public                 postgres    false    223            Y           2606    25006 (   customer_products customer_products_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.customer_products
    ADD CONSTRAINT customer_products_pkey PRIMARY KEY (cid, pid);
 R   ALTER TABLE ONLY public.customer_products DROP CONSTRAINT customer_products_pkey;
       public                 postgres    false    225    225            [           2606    25008    machines machines_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.machines
    ADD CONSTRAINT machines_pkey PRIMARY KEY ("ID");
 @   ALTER TABLE ONLY public.machines DROP CONSTRAINT machines_pkey;
       public                 postgres    false    226            ]           2606    25010    products products_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.products DROP CONSTRAINT products_pkey;
       public                 postgres    false    228            _           2606    25012    users users_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY ("ID");
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public                 postgres    false    230            a           2606    25014    variety variety_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.variety
    ADD CONSTRAINT variety_pkey PRIMARY KEY ("ID");
 >   ALTER TABLE ONLY public.variety DROP CONSTRAINT variety_pkey;
       public                 postgres    false    232            d           2606    25015 ,   customer_products customer_products_cid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.customer_products
    ADD CONSTRAINT customer_products_cid_fkey FOREIGN KEY (cid) REFERENCES public.users("ID") ON DELETE CASCADE;
 V   ALTER TABLE ONLY public.customer_products DROP CONSTRAINT customer_products_cid_fkey;
       public               postgres    false    4703    230    225            e           2606    25020 ,   customer_products customer_products_pid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.customer_products
    ADD CONSTRAINT customer_products_pid_fkey FOREIGN KEY (pid) REFERENCES public.products(id) ON DELETE CASCADE;
 V   ALTER TABLE ONLY public.customer_products DROP CONSTRAINT customer_products_pid_fkey;
       public               postgres    false    228    225    4701            b           2606    25025    cart fk    FK CONSTRAINT     e   ALTER TABLE ONLY public.cart
    ADD CONSTRAINT fk FOREIGN KEY (pid) REFERENCES public.products(id);
 1   ALTER TABLE ONLY public.cart DROP CONSTRAINT fk;
       public               postgres    false    223    4701    228            c           2606    25030    cart fk_users    FK CONSTRAINT     |   ALTER TABLE ONLY public.cart
    ADD CONSTRAINT fk_users FOREIGN KEY (uid) REFERENCES public.users("ID") ON DELETE CASCADE;
 7   ALTER TABLE ONLY public.cart DROP CONSTRAINT fk_users;
       public               postgres    false    230    4703    223            �   �  x���M��0�����[�$��ED]������M33q�&4�t禂��y�#���|���W2ݙ��Q�������9�Z5\k	V�(}3���}5`�
�*^�C��O+�oB՞����S�'q�3HB�� �ޥJ���Z�^����i3�-���DaV�I��w�k-�f���`����s{�ߡ�І������f��/�g@0o�U��'[9d�^��;/�?�������3d��R.C�Ȣe��l��MH��8g�sY�W���������_�� ��pQR}
"���q�<�(M'hq!���J�m���m���΁>�������W���w�?��]����|��*���#-���X��� ��[\�dP�e���c��yNH�qF�ی���6#XQQώf0!)9#qD���?�����7Ps<S�v�<+Ԝ.�cY�&Q�����97�����8�n�ޓ��_I�G�      �   |  x����n�0�g�)���J�"$��H,]L0I�Զb��XQ�:WjGT���Vo�Rm�^_$�����&<�a4�(H��㈏F��S7�q!Pę�L��8JxA{�̨HRE��31uoD�^�w3>��|����������o���yqn�(�p����N�)��ȝV�{q����_ὖ3=�+XՃWyLX��8��C�H��,��<dib֕^�� ��!^��0>��|��@áY:I�=jQn�+-lzGb*�*�ft������rG�\ޛg��O��{�p+�}�����f�T�D��`�U�Jr����oΓ���G$J�H�clcZ21�5���+���oc��n�o��Iӹv���H      �   �  x��R͎�0>;O�K��M�$H�M�V��R��r]7-��Q������3p�ޠ}%7M˲��f���|�x�R��Z�mY���z�r^�-�k$���X�3�ƛ]*5���]���C!��l(�L�}��Bx���Y���K�!#!�j�J;�hؓ�ʦ�>|=|;~9�:>~�?�!b ;�k�},R��KӇ?�����4�[��ΡPY)�Wy��ZcF���&� �v4L�� h��������z&���9l��Y�%
�'�
21�KM�5#���U�g�����?�\�pJ.�W�:�'pxj�>�2O7{�~��6��x�#����ҙuW�bU�{�o^��F�U���0<]�����7�_�F^�u�,%�@�^Ehy9V���4U�ͪ�A�s]5wG�Y�zqG˻�(�tI]B�O�sWlw5�ޯ�\���Dy���t���Y��38d      �      x�35�41�4�4�26��9��b���� /e      �      x������ � �          �  x����j�@���S̪����bIS|�8��iRJ���ęF�9�݆�/�]�m��R���0~������^`f�����s�T��Jɍ���1ƫ�ʪ�V�KLwWIs�J,�rV���5�y�2섁G�VD��%>L�^IvE!%�L\�����	+���,Ӣx��˛���
�;���Y��ѡ5�2Vq�ldD���Az��Lj~�P����b��z~�X��-H��|�5ӂ崞u�;��Z�#���3�5s���ba�wۛ���U��7�#R��W�A���+����s�6���J&�����9�}��O��bx��"v�!ӦAdp)W��s��;q=����6�G0�N��8��Їɠ�'{Po՗��Q?t�fV�HI�W):aC}4Y��hBs#z�&~G=�Pjr�5������~�"�텶k��$qI�7<��;z:�봧�n�%\�$��9�P�XR��S^�)\�8P0�Q���2M�'kU<G            x���ײ�H�(����2��=��Z�HB�Ѐ�Y$	���/xNVUVU���;�L�#��U�G����ݐ�c��5M���@p]�_�_���5���4����u8N� vsT�1cE�4�`0L! ��C��g]ی��~�a��7��@HdC0��G'���q:|���K�=�߼�ڳ�����&s<�Ig�Y�M����'���0�Rߜt�����-}7��B�A�~���	�����ɷ�w,����o��Eb0E�$M�820
���$�e=��g��"������i�cV�oc�	�,'�Yq��cҡ��i�{�7���y|�/��a�ʛ���o0�Ә�p
��g�`ѥ��'
ǔ��o�.@�af�Ɠ�0�;��D�+�0%��������3�{����޶��]���mp�����_ڊ�l�]K4�Aα�ۨC�)��?'9/�g+ݞ��=�w�a��7�`i���<��8I�x�^�wY���y����|ĨR(���s���sa���Ȍr�?�+�`o�C 7����S9Gq^>�wy�W�Q�p�|{���E�	]/����v����u)+<\n+%WJ�|�k���؅�y�JV%�&fk��klK�u��xg����h�}^/�����7�O�v�3܉k�_��c{8\�[2�<�y��z��{2���Ś٥u
�:#�{���c|~
C5� �#;��`��耽�%7rU�K�Yn�������Rx�I7#P� M h��~V�vHb&�1A��E������2�{�n�6�~��k�9�L��Y.��W	�\���ߺ��R@,�!mP��^Be��i���ĪI%Y�`X���v��_p��a��"��e	�&`�+�o�$.��������T�\E���;���TC�6�UE-%�V둞{Y`��Q
�{G8�!+��ԏ  �N\�U�.�4L��;
q;0^;ɉ��aܬ�NXHH�x9P��'����cCk:��Μ�Q»�txW[�;��^cׁP�%��Ĺ��S�����Qu��G]65���2+�5|�<Q,���h�(ױpkc��ĕx�(5�a�h�C>�����L
��qRۉfa��G�-��qL��t���7'�r3Y^��3i�C'��i�(��rGUw��b����'�������<�[�j��]��jʴ�y�����z�d���v%q���������6[u��gS�� ����6��2��C���M%��;��+�����-sodHI��e�L(�a.t)㕤��i�v~9�5=�Ge�~D8�Mv�c�A�vI�J��a��G�G)���`�`�
A4}v�
�0�R[�[�VӀ�>=�aJc,u�zk�Cʅ�ɶjU+�21�WPE����`���69��H~ K�wYhKJ=��t\�+���J��`m�mRV�ln�渕w���٣*lZ:^���	v�e�-�?TjD�y���5�͓����.��iD���%v����ׅ��u��zVQ���Se7�ǞaM;^uE��j�z�$9�n=K�Q�����^Iz���`�KCv�k3�?�nC�4$��v���S�
�ȸ�N=���^ک��,h=��JY��JQd8��w��0y;��*�B��u7@tN�9���[3�N|����|6B4,`�e{����׻��*)��T�0
)뙔ݘ'e��jP�D8��[(F4S� ����H��� �+c8Z���w1R|� 4%-��-C�hX�qt��h�	��N�Sop��ih�Ǿ���(b��y�����Ά�n[�����A�b�I�� hp�#d�*M �cT�W����Bd>�(�P!��������ʫ-�Вz}B^�����E�������p0��{���ަ���4���g����q���U�C�+�m�������Q/a��L@�<�A�O?����=y�^����!s��fu��=���������L�..F��i�x��zHzB�
hzU��|ɺ^Ѹ]Z�ZD��nVe�:9xM&fXf�����FT�t��x [����H����Ũ��8Ej�<O;[	�t$0��dg0�k#��c����Y�U���4��|��8�t� ����C�P6��!�Ԡ�69|�J�y7T�)$��<���{Y;�KKv�`����-M��'u��<��.�%���:* ?��I�	�Ƣ����BGW_�lW�DwO(C�)3�����܉$��S���k�#9<sk�~�p���2��=op���H�Q�cz��s�%ZO���$Cxk���v�z[x��^���4.4D\LX�V9۵����&�S�B��Jx�ލӾ�!D����逶�̕�:}�������8¢�Dd$��� �ԣ�'$��C�:�o׆W�5o����s�_�N~��kv�c�� ��Kd���VFӄ����H�{5�ޒ�����`��j+��t�7h.�D�VQ��` �V^SY!�УVr(����;z`��^�x����H!-)��˨��*�T�l��k�@n����$�ݥ�@}Ȕ5��f�[&��Lh�Ƌ7*z�ncM*&��벣`J�fi�L�B���Fjbp�OOh�{�(g�7|�ܥ��nr����619K�b��*Y0�Q�I���f� �^�r�6���M�S���� ���ъ�RR�v>Z����
���o,���4�a�iwd�h����Ϲ�6Ս�A
��w��.[ç�b��9��LmR#n�L��^�Ǵ��)��&�WL4��w�X�&fȩ}��n�z]�]�:���F��Jp`7�T��>%)�KPQ<�]�+��Y�-�/�K�уt�0�Mm��[W]A���r��"��E3NStr���]�M�l�aO�~�{��^ſ^�9���}?�D��Xf�����E�7ML�Cz[�1����l7��nm��%c4�O���Eu�;c��v�����ș�-+.!�Udv�41�	L�IƼ��fy��n�]�M\Wj��-������U�^ܞ[��=�t����M���E��}��w�?i%h:Rc�v�ka6��tt7l�ڏ
����G�l縭�o��(ϲи���ɭ�'���~��]�<3��2�y"#��$ .�W"����n�V4~ ,[�i��Zη3�x��j�:�Y]]�&�<]����J6�]su�e:�A#� n�5ȏ�d����L���6
f"��W/P����Dn�j,�5M���j	�V^7#�P{A�l\Zo��E@��`�i_'�fR��R���=���Zz�)zE �n��s#T�#�z�,�%i�Ff��%�39d~��ԫ�׵�����ĭPp}(O��k�ߴ-�����yn���S������܌�"�Yc�'�'�#'���BdC�F;-���wA%�0	x@�a<��ގ��sw9�zܱ,"Z�ng(G���^�: �!��k\�v��J.�|�S�뀴-�F'�ZC��R@8��jjt����u�q�ϱ<鞠�K&�t����rH^�*�+w���M�g����n�9�����
,��!U�cryY	vf�a1�6�����Bf���]$8:6�q�1YS����804�|Ƴ+�Wi�;�M:�`�P}���n���ǒ�p���R�[����cV"�J��1aC�T���x�e	�%�\�+.���c� ��Q���NA����>��!\�r������?#�����S{�2Kģ[k��w���:<��<��'7T8��n^o�D��΃3��GSR>�;tkVų���v��9w܌�v�tH��~�	�`���Nh�xS$��uIi�2�"�;;�z�t��Z�s�e�Az��F�N����#1��r��V�ȵ�So���*X�q�j0O|U�F�0o�6U��jg0ǃ�R����]46.�nY��m9��*vRē�81y������b0��m����C�������T��Fz-0,��AA�V�NH�B� ��;U �)eC�'�QQ��"_��z	��<y����.ᐏS��v����h��w�@�����Z�Ϗ��G�[�����?,�"�P�o��N�꿷�R{a��z��큽��    �A��'�r���n�{92�Z�T���ļ��[~]������ȳ�I��9�Q�gc�t�u���r���s����� ��*�㦘#��{�rP�K�����_�#5��Y��~_��V�zab��@�a�����^�c�'y����Y�e�K1�}|�ֽ��獇#��X0.��(�{�h�[I��MV.@�p��l��-C���0��K㷥�?�g��]��D��Ə}(s�2���[-Tn큟�L�QNd���tۦAd�ԋ�5��[8��c��Tӣrq�B^5����×��C��D�L��%�
���N>;<Z'wl\$Lk�ţpM��3�܂Ȟ� A�T�&�+F~)T6��$����?:@?�{A$ Ή�?�.,T]J�����u/�����e5�ɣ:p� ����4�@�ʹ �)���U �=!�g���uI�Q��z\��� e	{,�)I��"g�i��}"�5�߁s��Ngj�ȭ���lG����Ρ�B�������h-�W2%��pԓ*�4�D�#�����>c
7��)�Ncz+Z����3]TKy�ȕJr��H7��hN�Fd:OO��'l�hܣ.0����`!]�4��qn�A�fs�r�\P�^XAMd�'�:����a������R=-x�ih�6ҐA��������#���"�0	 _��Qky�FR�r;���,z�ʺ�6�#��:N�Q��z� W��w5��ޔ�=-4!2�h�� >�,U�����׼�C�s%�x�ĸ��4�G(1p5���,��72NȉW���8÷FcO����i�h�}��ƠV(��|��uJg�a �%S	���T�Ċq(�8s��D�Z<L�3v��i�S��\~&6����Z8�=M"�ť�D��������#�����~��<}+~qd�r�88p��Բ���\7��y4��u���B�=o�C�J�e�g-�g|���v��J����g΁��=�;}��"H��d�M��v��&3m�LMB4hFc��ԓI��T���2�%��8���o!$��1�ii44M�;���'�D��pV�b)�4r����4踘ˀ����@�\�w�Q�P��Ԫ�
�R�'up�S��*\��;�B�h[�|{��n���BB�n�j3��$���^�&Z&#�K�T�є���w˗l�4ot�b��1�F�-�ťF׏C2��dE�g���Hr�;�4��#?�9���'�"VRӃ��3:��N�ba�!�U��^*��F��5X��Ru�����},�ea2���.>�Ū�x8r�q�L�T��S9>Ec��ޒT�nOG�r
��
)�ů�#�FѬ[�.]1�n�ө�f6���i�� g���a�,��=��H�t&� !R��0�e6�ヱ�"J&�R8	a�f��T�"�}�a;DoU��x���y5o����@G����.����sl��,��J����S.],���|Y��s�{�,���|dJ� E��-��R�M�O��dϰ�d���m��B���.8]d���ZYZ�2S
� -��u��a)7�mh�A����ɋ�%AM��������� `f�Sa:8���S�D)��Vܸ�)�^���=���xڪ)q��o�v��=�N_���"v)po"�;������?]n��̙h�:c"��ENCԅjw1�li�L���I 5��fc�p��)�E���e��]'Q�b( �IMBa�]��kjQp�x�rV��ZB�3�K�w_��5��Jz@�+����|�z�I!0����9�K�Tk�����R̿���A0���<�߹*��:�0�}K��>���?x��7��Hu�I"I%!�>SP�T��+a��{��|�p��N������3o��J�1�H� ?;ސ���?��C���p[��I�����m��i4�<�����fJ�	����D ;9
�?U�X_��~4�z�9�Y�����&����L������k|�!�9|#�)h��N?�����s8gD4~ÿ�cN�i�m�F��*k��'vV~�j��3l���>�w��މ"�w���s�z��~B�����N�ׯ�0���7�oi�o��A��u|c��`�Na^�	H�_�o6a��?��4m�����x��=�� �Y���M��̗?��� ���DH���Q�{y0��M�u翜��~^7��>}n;ϗ���U0ۗ`�O�+f�-�ʃi���õϡJ��3�d&ل��|_�ן������95}��d�i�����x��M_�~�\T����"��d�/3�0w��YV�Y��v9���3������`�s��B]�rW��Ic.7X��g/_�q;H=���0{eV�s�~����3���c��=c,�������/��. �27F��wc}���=g���߯�1�0�1YX��C=v>xW��� ݩj@�G�[$�t4�}��nq4,�^��+������I����n;}���ֱ�J����u3w�ڡ��z����H�#K��V���Q��D�9^�[:��$/�����gN�gu���9���s�@��ĊΉ�w�����RZ��a�,Bt��6㱾��S!��Ƀ��b���m)
��5E�7���v��	=�8�?:9��J����Y�8�,�P�M�=v��II1yy �P�l�G�I�֖�(�"u@d+�gw(�}����5��<��#����n��I/O���%o��tH�d<](�dZ+Tj�IG$���Zd�#�v��K�ZX��$�s��TRd���v��X_��f.�!���Gj��`�D24�<6H�P�Y�����Z�4�j��U�_a�h��-'�Q� �0����$i���bҒ����_|x��<J���<pu��?Ʀ��G��ȳL�tw����Z�9�������.���R�� �gjs��^[�ive�����^���u�9��u������Tc����n�T��N�bΕ)�)h�<�ӛ�<�w�p�k�P!����Q�܏�`c'Af������7�BB��1�TxE�?�(?�`�g��!2�#��z��5scs_��7���ڻD���xR�PF`�/�� :�B�V���.O��k"�'?�ku
���6��@�W3XH��^��(�A.����u!�c��t�����!��͑rz�iͷy�i��qj�r�D=cn�n�yt��(�?O��I�M9�9���B;,|���68`W����:�.��G���kp��Y�a}./���.��W�rp����RxU��R8�psUױrF"�q���n� w����+R�s�8����2%�(#��6�� ��C6*T�e�L�����hV6���W�����U��[���ܴ�hjϝ[���<��P,���^(â��<oQ��q�Xߗa{8���1v���^5������)+��I%���<m��~�7���t�<	*.j0���^LN���m�n�����XvQ�Y��
9�j�11��J)��u���>m�"�T�8�p���T�u�� -R*�Ӻ�:�҉rs�4w;p�d�K�U�n��W�%n�חF�N! P����u�|-5�\�U<^�fC���ib�uy8(��3ą�L��7�y�\[�.����H��3/�8��#����䲇$xSv�����z�B�o3l؞���3�ft@��i�*50JxeaFq�j07N�J|�Hu�	l����1D����5R�1���G'�����\�	cDXj�&��9\��p��$��~a�x�Ԫ:��榮��+YP����Z�B&1#d�T)�I��[��W�VwK���6魻>�~�t���Ty!���Jw�L�QO���:���4^`6~��!����WҩEl֤��(ƕ;�N��	���i��?$�*��@��O��T��~*��He�(�Ń7���-��'���Fa\�H)X�(��z�C���������lw���ћ����w-������RuZ2�[1�V~Xn�;c_�V}��R�t�?����(ש�Qe�����4� �  Ћs�����I¯���9��R��ӻHF1Ͳ5�o(�hd.~C�l�#�$��&�qy*~�.G����[��1y+�1�1'8A��4;�����E��"�7o&�l��A4N"y����;��;�Î�s��g��Y�5u�z�e�@�0���B����J�O��7�p��
B������:�y��^�q��'
�����w�L�e��gNO߻�>����G�;i-��ۂ[$E9 "�s[��;�����l�Α�L��؄yK��ߧ;>�P4p��p��8@=$
��5-�O<:�q> �z@��qj%ފ�I�y��n���lw�0�+*�u������oqJE[��f�i$L¬+�2D0!�`��T�v/T�2sU$�۷�����$�Ǔ�)d4�SI�m��9�ܲ�,`�9�M��l��j��9��W�`3��0��_�r��6a�������򳲚��b��N�����ߟt!�[~5W�G���&h���ܷ�����C��nG��}^c嘌��j�fD��B���g�HxqX>F�Ǥ�d?HeҢY�����6�ԛԥW=FE�_#�0�s���w�2Uz=�]��� �륁�4i�a]W}e9#E�vߞ1�C��Τ��t�+~������H��Y ��WuuK�4���2?�;a�e�5���:s}%+IUؗ'r��� ����� ���\#�ȼ��{���yZ�W� �_��Vs���&��r�V��&`2E	��}�(3ܬ�/�5�a)��M
��UG=�!tt��Zد���g�� �\c��G	x� w������Y�7�{�n��\�����ի�"�
�*S��3+�bD��'e4ӵ��c�)���D��6ud�Mx����>(�Qw7��?��N���� W���ۋӑ.�:�Z�O�4eJ�S'���M9BN��+f)���K"/*Z��駡-�,�T���=�	-���Ԍ�(}�_����e�x��3�bΠE�/�6}-2y�k��!.؝��gFB`��u���F���
"(iH��/�}�Of���J�a�	c��2rw�$��lBey��Ήo��47X?�dDz�n:72z3b
&V[���]z����X��KL�ltQ����s�0"'�m@؎L�X�#��;�҇�p[O���Zl�6�mr8t���Ĳƥ��n�"@¢�W!|�G�g�@=�|�A�T�m����Fʅ����B��ѡ����<�+�T���N�$�v�C�"�%��<���$�aR4�^o[6�g��6�5��w��鳴��\��YM9�V�����ޥآ��N��Y��K2z��.G��૆n�莩=�C/s@(\�ݐYf�c��5�	��@� �&{���ΌY��L'� �cV,��V��}pI�j����A�� ���Tg\�a	�L-5��ueX@N|v�6����PV`�PLzx���ؽ�]�6$(K|�Zi�/A4 *#���#��1/=\Pz4:@�g�ND�K��[?�vb|0o�S"6GK�c:���*�3g{��۴$@�����`xx8E]���TC����+�*	��ҹZ}�	�s3Dܟ�sk�4��ܫC��u�@$';�P�,��9s�u&KZO��f�@����h�Ii��O��SS~��Ś���o�v����CR�����ؗ��s��<�1��)�CF&�}�~'R7��"~d�,�(z{����3Gi��J��p+�y�Kr<�� 2S�Z3DK�Gl0�W6j����3>�Xpo^�P$���Z�4��x��i�O�?=�G�D8�ؔ��sО<�6�k1J������O#w�C���+>�d��^�<�J��(���r�Ҍ	#�������\V!h��ݍn8�!�[�B�M���њ�gL5Y�r�d��CӨ��p�>jrs�����/�x�S�4�c��Iӻ�m�Z\ i���#d㌺/s��跣�OW¸��Q��d=>d�GP���њ��D8�Lޛ��Oc��(�'Ao���z5{&t	�5��.�Mq����¥r��~*.%2��f{5�z�ը �2��̆t�weOu�6~�jYؖ��JU�����#�����,&��5i�<���qY�)��VS�
��hu1�Ԡ�.�y�^3�EX�ʼ��{����,ŝ#�`��5IlfK�|����բh�tF=��اˍ�
��	2թJ	�}n3!}r�KM�8Ò����@0��_1%'���:g~�z��b��O���ө�1U���<��f���>���6���UHK��`�9<c�;[�v���\�������'�wK�"JF�O���F4 &��˝�/
�cA��á�w�s�����^�������f���P�f\v���t�f�� $1�G/uL�`n>Ξz�={��c��!�(�H=ܲ����,d�}�w�sاQ-��;�ۊ*VS������ϖX�����~<������oM,�e�OY�V�(	��i'��b���������3��)����=O���j˱�e��h�Է�^�%E3g�����{�DR�Ţ8�`$�Q�g�o7��) Gj��ka�h���G�)"���h�B��z�VZ��)�g!�N������Nҋ�W�~R���C��ġ��-%�48K�e��Ū�����1̜v3O��U��G*�B�-酪v���1y�o�,�g�m�p�ty ����Ǣ*Ϊ����I���d#݆��I��I���h	h������a�����m}à���*z��u��_�4�&}"�^�]So�;�<C�W/�}C�hK�*Y��d�N}��V�}I�:�;����y	��BX�}�ٸ�.t���ࣻ�F;#�։�0g �+����\a�� B���|y	�L(��u�y��{�mc1+��aQ�� uب�-'�.�@��zM㭓�ԳO�%kư@&�����H���v&����!�ɖ����;h�7����������{������|fy���������B����f�G���GH�0�8������/�I�@ ��o�v�N��#��+���uy��z�E��.�!������ǟ5�ۗ�5���`^U�F��zk��Z��Պ��Ǖ��y�2���r�AQ���,����/����k�N?�y���П�\?��_��9����G#?�7���������{���~�ƽs��7x����U�����=��7��Q��������>��['��~&�Y�ῙS8Ds\����6gh����Y�s����~�����ao������G��o0�[b�ۏz�6���2����~c?��u�'�?��������y�������Fޟ�Ї6˿_۶����Ya��a�i�]�J�0�<I�\�'x��SG$d���q��P���0���'!��Cޜտ+_���w�~�4�;A�w��!��9"����M���I�����r\?>_���
�M��~*
��4IB$��	�����&�̇rW�����;_��u��&��R6��~W�&�~�n����H�o���R~�A9��Y�>+|$�Y�c8+�>t��O&q��)� �C����޹���"�����|QEo��z�Y�Tsz�1�O?�ҵ�G���'�=�`b���
��O�W�8�q��a3~�����C��C?K�����������8��6�������g ���S\��m�BP�ǯ��s���~i�&��c �����0��D��҈�`�k�����7̩�,g�u�����P�}�W㻉�Y�t?P���?��g��/_�\�-�醴C�(���}����/,�4�Ϲ����ª��$,��ܣ��4l4L��g.�۫8�o�Ok�����\;�J��/�O��-���'�NW�m����D����ׇ�N�>����-���$��t�	�sD����������n�         8  x��X���X���~E�J��G^1�1C�s&�b����6�h����v:�����_z�[uy7��M2�Dpk�����)��ˏ���e��x�]���@�	e��~����g(~�����<��)�n;`g��N�%X�i0���.k-�ޭ���0��)����Z���h�?b�|w�����_�}\ڟL���M�������ys��x�W�^w�Y�M0��n}����¢�������}���_�����þ�|�o'�5�]T!��M3/�ue\ ѩ�mO�y�s��qAmFGq)J��'}�?�wǭ���a��ޭ���(w8���Ď�F;>�3A��w_�+�����8[}`�83�{��}TSدu�x��Q:8�ҽ_���7��U��"U���_��cT�h�"3&��DLC�� L���(��,Z�������]���s�wf:��Iq�m����Z/6z����Qu�� �E�b8ܓ�A*�4E�o��������E��h��rԫ���.I�J:���V��߁ʆ����nH��Ԟ��$�>���ck�_�结ooEj�?����|��2f�0�����]� �-���2�D�qp�N�i[�u�C��kA�v���+~ 1�f
9�(ˊ�ܳm��G�
P���g��Ip:/:�n����b,���U����R�����-�|�����+l+f8�����S���q��y��E�����Bit��_��c��s�ʦ0A�S�b[�V
��n�;ݸ��d�z��+l�"�s %�b�Ƒ�2(�m1O"��7���v��C<�`�J�9����7�q���y!��Ah����ɺlsj����i� �l���QS������XM�{�=�-m���)>"� �rkթg�3,�8ʪ!)�)�d�/M��xi��˯�EDB��oٚ2e�$� ��=o��?g��]��	��8:��3���޼��U*��y��9d��#�X�Wؔ$ ���~�]�)���B�0������=�"�'�6��f޾;_����ƩW=�l�uo@
\)
��w�E�
R���Tdk
�t81��A��!U��?������&���l5�m��n�a��c0&[�S=ח������%ؾ�Dԗ�W�8�X���e�C �I��{l�4����P������ژ�?H����Eu�f�|0��N��o��WS/y3�-)!�h��X�⑎��s�m���5}�[�<�v�W���s��s�$yP�/�ٍ5G9]y^�R`�	j��͡8��K}3Ҏ�@V4��fm���ʝ'�aD�HE�=o�H�N�����"މoH=6`���~��Å�Ӭ��h1��)�W_���S��#�.��#	�@�YQz�����}��8MA���%w�����ŉi%�4m�������~-/I�_z��?b���vsdD�^$$x?��o.k��ƺhJ������Á��lۨ�{wQ>�ڣ�\�[^^����%oc�,o�W?���G��C����,Ğ�Я�/�H�ͽQ	�niz�x�3���!�~�JP�K�=N�1��N_zB�&��?<��ͷr���fU�!���gM�&O�d=���}��.��u�YY��:k��eUXUS-���(�,���W�0�T �9�s�!+��G|�+��x#O���S��+UG���b�b>�w�t�<zGb��V�/��v���;��Mr�����`Ϻ�/sl��mý��ӳ�z���b;i��(����ܑ۾�:��U���V�V�y.+�L��x�߄/!���0Y�2���5�m:��q�}Fzz�����C�(N��a�w�Y�h�Kn?�yȭ]��u^>^�`S_�_�d,(D��oLX}�z�h�FJ����������UUBƴ~nw����j��@ 4�֕$�j<jF�ˁ�����O�)j�T!�Y�Y��0����ҧ/L�������ܻ]K�7����L�����Sy/��+��FX*�t�/5��)a̱��g�2GH���R���������Qcx �x�k�Ѩ73��黕dr��V�+��[@�N��x�)˗ش�k�|ؕm0[�p����>���ă�kJ��v����Kg����L7AtJu5�e��`u^63�o�=葮̻��%6l{�`���tZ���48ZH�Q���F�s:��s<.�gB�%
A���y�v�2L��j|��R��8j)w��̋ӗؐ���΁�5|�{��Y 8P{��C����왑\��*�E}*�lk������@����W䜍�Z�3�u0}���g~$�IY~��9~D�#5Ց�BP��=��~��z�Us�U)�Gw�<g�K���5�����k�ԗe圱 ��з��������������!�K�3��;�������������������r������~}�W�ޯ����)_���~z�z�ҳW�Q# 'p�^�lV
Z�}O]e�H�W4��kNMwy��{_���� 0�@�@[S���%��Fc�~��}���g՞9n��l����.O]��Q��ɨv�p���s���w���K��R��vl�)�T�9�|���OʷK4�P�ߝ�3[�d�S&�8�֗����5h�E�t��4���ɚ�;�����]���ݭ�G���sN��y�R��X���>�]���eY�Ӷ�g���~&75:�v�^_q=>�ɴ6���g����=�}A9��9�?���Y�Zhm֦'C�ה?�4?W��ԈJ-�V��hQo������+�<7���������>�Iȶ5��,%4z�!�E�	���A�9����o�J�4�Ȇ�ѥ^)��=j6���Ҭ��	Ew��`W\v3=k��d�?�_�|�_�ҡ         �  x���MN�0���)r���8 l�*'u��G��@� X�a�X�`����s%�ƕZ(U+Rf޼O�Å��S�}�
9�0�Ϯ`�PS�BV�U�j!�X�'D�	�j�	rF+R�K5"�T�c����˞}���}j��#]+����c{o���e_c��f�P�f=�Ü�١.:�S&�܎'c����q�V�F�~��������~�/�/̏Ox��'�w��O��9ʗ��,�N�4�[[/��:]E�\ �%�}�$Ն)�_��,\���Ћ�BC8L�tS���OW��H�40�sJ����t|JK�@�sְ�v_�
Y�Z��0�CFi��=w���$�#��W����k#��e��]��X�9P�o�eF_x�zO\DK�'��	�u�9�M�ח���w"�Eg0��o{k     